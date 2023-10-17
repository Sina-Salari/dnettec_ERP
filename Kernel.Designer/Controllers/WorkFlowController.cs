using Dnettec.Persistence.Common;
using Kernel.Persistence.Common.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Kernel.Designer.Controllers.DesigneVM;
using static Kernel.Domain.Enums.Enums;

namespace Kernel.Designer.Controllers
{
    public class WorkFlowController : Infrastructure.ControllerBase
    {
        public WorkFlowController(DatabaseContext context) : base(context)
        {
        }

        public async Task<IActionResult> Index(Guid AppId)
        {
            ViewData["AppId"] = Request.Query["AppId"];

            var Result = await Context.WorkFlows
                .Where(p => p.ApplicationId == AppId && p.Status != Dnettec.Persistence.Common.RecordStatus.Deleted)
                .ToListAsync();

            return View(Result);
        }

        [HttpGet("Designe/{Id}")]
        public async Task<IActionResult> Designe(Guid Id)
        {
            ViewData["WorkFlowId"] = Id;

            var data = await (from WorkFlow in Context.WorkFlows
                              join RequestPattern in Context.RequestPatterns on WorkFlow.Id equals RequestPattern.WorkFlowId into RequestPatternNull
                              from RequestPatternEmpty in RequestPatternNull.DefaultIfEmpty()

                              join WorkFlowInput in Context.WorkFlowInputs on WorkFlow.Id equals WorkFlowInput.WorkFlowId into WorkFlowInputNull
                              from WorkFlowInputEmpty in WorkFlowInputNull.DefaultIfEmpty()

                              join WorkFlowRespons in Context.WorkFlowResponses on WorkFlow.Id equals WorkFlowRespons.WorkFlowId into WorkFlowResponsNull
                              from WorkFlowResponsEmpty in WorkFlowResponsNull.DefaultIfEmpty()

                              where WorkFlow.Id == Id
                              select new DesigneVM()
                              {
                                  RequestPattern = new DesigneVM.RequestPatternVM()
                                  {
                                      Controller = RequestPatternEmpty.Controller ?? "",
                                      Action = RequestPatternEmpty.Action ?? "",
                                      Status = RequestPatternEmpty == null ? RecordStatus.IsActive : RequestPatternEmpty.Status
                                  },
                                  WorkFlowInput = new DesigneVM.WorkFlowInputVM()
                                  {
                                      BodyJson = WorkFlowInputEmpty.BodyJson
                                  },
                                  WorkFlowResponse = new DesigneVM.WorkFlowResponseVM()
                                  {
                                      ResponseJson = WorkFlowResponsEmpty.ResponseJson
                                  }
                              }).FirstOrDefaultAsync();

            List<WorkFlowStepVM> Steps = new List<WorkFlowStepVM>();

            var AllSteps = await Context.WorkFlowSteps
                .Where(p => p.WorkFlowId == Id && p.Status != RecordStatus.Deleted)
                .Select(p => new WorkFlowStepVM()
                {
                    Id = p.Id,
                    Status = p.Status,
                    IsBase = p.IsBase,
                    RecordType = p.RecordType,
                    RecordId = p.RecordId,
                    WorkFlowId = p.WorkFlowId,
                    VariableName = p.VariableName,
                }).ToListAsync();


            var FirstStep = await Context.WorkFlowSteps
                .Where(p => p.WorkFlowId == Id && p.Status != RecordStatus.Deleted && p.IsFirst)
                .Select(p => new WorkFlowStepVM()
                {
                    Id = p.Id,
                    Status = p.Status,
                    IsBase = p.IsBase,
                    RecordType = p.RecordType,
                    RecordId = p.RecordId,
                    WorkFlowId = p.WorkFlowId,
                    VariableName = p.VariableName
                }).FirstOrDefaultAsync();

            if (FirstStep != null)
            {
                Steps.Add(FirstStep);
                await GetNextStep(Steps, FirstStep.Id);
            }

            foreach (var step in AllSteps)
            {
                if (!Steps.Any(p => p.Id == step.Id))
                    Steps.Add(step);
            }

            data.WorkFlowSteps = Steps;

            return View(data);
        }

        private async Task GetNextStep(List<WorkFlowStepVM> Steps, Guid StepId)
        {
            var WorkFlowNextStepId = await Context.WorkFlowStepMovments
                .Where(p => p.WorkFlowStepId == StepId)
                .Select(p => p.WorkFlowNextStepId)
                .FirstOrDefaultAsync();

            if (WorkFlowNextStepId != Guid.Empty)
            {
                var NextStep = await Context.WorkFlowSteps
                    .Where(p => p.Id == WorkFlowNextStepId && p.Status != RecordStatus.Deleted)
                    .Select(p => new WorkFlowStepVM()
                    {
                        Id = p.Id,
                        Status = p.Status,
                        IsBase = p.IsBase,
                        RecordType = p.RecordType,
                        RecordId = p.RecordId,
                        WorkFlowId = p.WorkFlowId,
                        VariableName = p.VariableName
                    }).FirstOrDefaultAsync();

                if (NextStep != null)
                {
                    Steps.Add(NextStep);
                    await GetNextStep(Steps, NextStep.Id);
                }
            }

        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Domain.Models.WorkFlow data)
        {
            if (data.Id == Guid.Empty)
            {
                await Context.WorkFlows.AddAsync(data);
            }
            else
            {
                Context.WorkFlows.Update(data);
            }
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return BadRequest();
            }

            var entity = await Context.WorkFlows.FindAsync(Id);
            entity.Status = Dnettec.Persistence.Common.RecordStatus.Deleted;
            await Context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return BadRequest();
            }

            return Ok(await Context.WorkFlows.FindAsync(Id));
        }
    }

    public class DesigneVM
    {
        public class RequestPatternVM
        {
            public string Controller { get; set; }
            public string Action { get; set; }
            public RecordStatus Status { get; set; }
        }

        public class WorkFlowInputVM
        {
            public string BodyJson { get; set; }
        }

        public class WorkFlowResponseVM
        {
            public string ResponseJson { get; set; }
        }

        public class WorkFlowStepVM
        {
            public Guid Id { get; set; }
            public string VariableName { get; set; }
            public Guid WorkFlowId { get; set; }
            public WorkFlowStepType RecordType { get; set; }
            public Guid RecordId { get; set; }
            public RecordStatus Status { get; set; }
            public bool IsBase { get; set; }


            public string Query { get; set; }
            public ProcessType ProcessType { get; set; }
            public Guid MessageId { get; set; }
        }

        public RequestPatternVM RequestPattern { get; set; }
        public WorkFlowInputVM WorkFlowInput { get; set; }
        public WorkFlowResponseVM WorkFlowResponse { get; set; }
        public List<WorkFlowStepVM> WorkFlowSteps { get; set; }
    }
}
