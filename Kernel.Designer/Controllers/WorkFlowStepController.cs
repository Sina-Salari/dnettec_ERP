using Kernel.Persistence.Common.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Kernel.Designer.Controllers.DesigneVM;

namespace Kernel.Designer.Controllers
{
    public class WorkFlowStepController : Infrastructure.ControllerBase
    {
        public WorkFlowStepController(DatabaseContext context) : base(context)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(WorkFlowStepVM data)
        {
            var Step = await Context.WorkFlowSteps.FirstOrDefaultAsync(p => p.Id == data.Id);

            var ApplicationId = await Context.WorkFlows
                .Where(p => p.Id == data.WorkFlowId)
                .Select(p => p.ApplicationId)
                .FirstOrDefaultAsync();

            if (Step == null)
            {
                Step = new Domain.Models.WorkFlowStep()
                {
                    IsBase = data.IsBase,
                    Status = data.Status,
                    RecordType = data.RecordType,
                    WorkFlowId = data.WorkFlowId,
                    VariableName = data.VariableName
                };
                await Context.WorkFlowSteps.AddAsync(Step);

                switch (data.RecordType)
                {
                    case Domain.Enums.Enums.WorkFlowStepType.Process:
                        {
                            var ProcessStep = new Domain.Models.ProcessStep()
                            {
                                Query = data.Query,
                                ApplicationId = ApplicationId,
                                ProcessType = data.ProcessType,
                            };
                            await Context.ProcessSteps.AddAsync(ProcessStep);
                            Step.RecordId = ProcessStep.Id;
                            break;
                        }
                    case Domain.Enums.Enums.WorkFlowStepType.Validation:
                        {
                            var Validation = new Domain.Models.ValidationStep()
                            {
                                Query = data.Query,
                                ApplicationId = ApplicationId,
                            };
                            await Context.ValidationSteps.AddAsync(Validation);
                            Step.RecordId = Validation.Id;
                            break;
                        }
                }
            }
            else
            {
                Step.IsBase = data.IsBase;
                Step.Status = data.Status;
                Step.RecordType = data.RecordType;
                Step.VariableName = data.VariableName;

                switch (data.RecordType)
                {
                    case Domain.Enums.Enums.WorkFlowStepType.Process:
                        {
                            var ProcessStep = await Context.ProcessSteps.FindAsync(Step.RecordId);
                            ProcessStep.Query = data.Query;
                            ProcessStep.ProcessType = data.ProcessType;
                            break;
                        }
                    case Domain.Enums.Enums.WorkFlowStepType.Validation:
                        {
                            var ValidationStep = await Context.ValidationSteps.FindAsync(Step.RecordId);
                            ValidationStep.Query = data.Query;
                            break;
                        }
                }
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

            var entity = await Context.WorkFlowSteps.FindAsync(Id);

            entity.Status = Dnettec.Persistence.Common.RecordStatus.Deleted;

            switch (entity.RecordType)
            {
                case Domain.Enums.Enums.WorkFlowStepType.Process:
                    {
                        if (entity.RecordId == Guid.Empty)
                            break;

                        var process = await Context.ProcessSteps.FindAsync(entity.RecordId);
                        process.Status = Dnettec.Persistence.Common.RecordStatus.Deleted;
                        break;
                    }
                case Domain.Enums.Enums.WorkFlowStepType.Validation:
                    {
                        if (entity.RecordId == Guid.Empty)
                            break;

                        var validation = await Context.ValidationSteps.FindAsync(entity.RecordId);

                        validation.Status = Dnettec.Persistence.Common.RecordStatus.Deleted;

                        if (validation.ValidationStepFalse != null)
                            validation.ValidationStepFalse.Status = Dnettec.Persistence.Common.RecordStatus.Deleted;

                        break;
                    }
                case Domain.Enums.Enums.WorkFlowStepType.SuccessMessage:
                case Domain.Enums.Enums.WorkFlowStepType.ErrorMessage:
                    {
                        if (entity.RecordId == Guid.Empty)
                            break;

                        var messageStep = await Context.MessageSteps.FindAsync(entity.RecordId);
                        messageStep.Status = Dnettec.Persistence.Common.RecordStatus.Deleted;
                        break;
                    }
            }

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

            var Step = await Context.WorkFlowSteps.FindAsync(Id);

            var Data = new WorkFlowStepVM()
            {
                Id = Id,
                Status = Step.Status,
                IsBase = Step.IsBase,
                WorkFlowId = Step.WorkFlowId,
                RecordId = Step.RecordId,
                RecordType = Step.RecordType,
                VariableName = Step.VariableName
            };

            switch (Step.RecordType)
            {
                case Domain.Enums.Enums.WorkFlowStepType.Process:
                    {
                        var Process = await Context.ProcessSteps.FindAsync(Data.RecordId);
                        Data.Query = Process.Query;
                        Data.ProcessType = Process.ProcessType;
                        break;
                    }
                case Domain.Enums.Enums.WorkFlowStepType.Validation:
                    {
                        var Validation = await Context.ValidationSteps.FindAsync(Data.RecordId);
                        Data.Query = Validation.Query;
                        break;
                    }
                case Domain.Enums.Enums.WorkFlowStepType.SuccessMessage:
                case Domain.Enums.Enums.WorkFlowStepType.ErrorMessage:
                    {
                        var MessageStep = await Context.MessageSteps.FindAsync(Data.RecordId);
                        Data.MessageId = MessageStep.MessageId;
                        break;
                    }
            }

            return Ok(Data);
        }

        [HttpPost("Movment")]
        public async Task<IActionResult> Movment(MovmentVM data)
        {
            if (data.Ids.Count() == 0)
                return NotFound();

            var WorkFlowId = await Context.WorkFlowSteps
                .Where(p => p.Id == data.Ids[0])
                .Select(p => p.WorkFlowId)
                .FirstOrDefaultAsync();

            var List = await Context.WorkFlowStepMovments
                .Where(p => p.WorkFlowStep.WorkFlowId == WorkFlowId || p.WorkFlowNextStep.WorkFlowId == WorkFlowId)
                .ToListAsync();

            Context.WorkFlowStepMovments.RemoveRange(List);

            var WorkFlowSteps = await Context.WorkFlowSteps
                .Where(p => p.WorkFlowId == WorkFlowId && p.Status != Dnettec.Persistence.Common.RecordStatus.Deleted)
                .ToListAsync();

            foreach (var Step in WorkFlowSteps)
            {
                Step.IsFirst = false;
            }

            for (var item = 0; item <= data.Ids.Count(); item++)
            {
                if (item == 0)
                {
                    var Step = await Context.WorkFlowSteps
                        .FirstOrDefaultAsync(p => p.Id == data.Ids[0] && p.Status != Dnettec.Persistence.Common.RecordStatus.Deleted);

                    Step.IsFirst = true;
                }

                if (data.Ids.Count() == item + 1)
                {
                    break;
                }

                var Movment = new Domain.Models.WorkFlowStepMovment()
                {
                    WorkFlowStepId = data.Ids[item],
                    WorkFlowNextStepId = data.Ids[item + 1]
                };
                await Context.WorkFlowStepMovments.AddAsync(Movment);
            }
            await Context.SaveChangesAsync();

            return Ok(data);
        }
    }

    public class MovmentVM
    {
        public List<Guid> Ids { get; set; }
    }
}
