using AutoMapper;
using Dnettec.Logging;
using FluentResults;
using Kernel.Application.WorkFlows.Commands;
using Kernel.Persistence.Common.UnitOfWork;
using Kernel.ViewModel.Common;
using MediatR;
using Newtonsoft.Json.Linq;
using SmartFormat;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Helpers;
using static Kernel.Application.WorkFlows.CommandHandlers.RunWorkFlowCommandHandler;
using static Kernel.Domain.Enums.Enums;
using static Kernel.Domain.Models.WorkFlowStep;

namespace Kernel.Application.WorkFlows.CommandHandlers
{
    public class RunWorkFlowCommandHandler
        : Dnettec.Mediator.IRequestHandler<RunWorkFlowCommand, object>
    {
        public RunWorkFlowCommandHandler(
            //Dnettec.Utility.ICurrentUser currentUser,
            ILogger<RunWorkFlowCommandHandler> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork) : base()
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            //CurrentUser = currentUser;
        }

        protected Dnettec.Utility.CurrentUser CurrentUser { get; }
        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }
        protected ILogger<RunWorkFlowCommandHandler> Logger { get; }

        public async Task<Result<object>> Handle(RunWorkFlowCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<object>();

            var FirstStepId = await UnitOfWork.WorkFlowSteps
                .GetAsync(p => p.WorkFlowId == request.WorkFlowId && p.IsFirst, p => p.Id);

            await RunWorkStep(request.DataSource, FirstStepId);

            if (request.DataSource.Any(p => p.Key == Dnettec.Utility.Constance.RESPONSEKEY))
            {
                var Response = request.DataSource
                    .FirstOrDefault(p => p.Key == Dnettec.Utility.Constance.RESPONSEKEY).Value;

                result.WithValue(Newtonsoft.Json.JsonConvert.SerializeObject(Response));
            }

            foreach (var item in request.DataSource.Where(p => p.Key == Dnettec.Utility.Constance.SUCCESSMESSAGE).ToList())
            {
                result.WithSuccess(item.Value.ToString());
            }
            foreach (var item in request.DataSource.Where(p => p.Key == Dnettec.Utility.Constance.ERRORMESSAGE).ToList())
            {
                result.WithError(item.Value.ToString());
            }

            return result;
        }

        public async Task RunWorkStep(List<WorkFlowDataSource> DataSource, Guid StepId)
        {
            Guid NextStepId = Guid.Empty;
            var Result = new object();

            var Step = await UnitOfWork.WorkFlowSteps
                .GetAsync(p => p.Id == StepId);

            if (Step.RecordType == WorkFlowStepType.Process)
            {
                var Process = await UnitOfWork.ProcessSteps
                    .GetAsync(p => p.Id == Step.RecordId);

                var Query = await Process.Query.FixPattern(DataSource);

                if (Process.ProcessType == ProcessType.QueryCommand)
                {
                    Result = await UnitOfWork.ProcessSteps
                      .QueryAsync(Query);
                }
                else if (Process.ProcessType == ProcessType.ExecuteCommand)
                {
                    Result = await UnitOfWork.ProcessSteps
                       .ExecuteAsync(Query);
                }

                DataSource.Add(new WorkFlowDataSource()
                {
                    Key = Step.Id.ToString(),
                    Value = Result,
                    Type = JTokenType.Object
                });

                NextStepId = await UnitOfWork.WorkFlowStepMovments
                    .GetAsync(p => p.WorkFlowStepId == StepId, p => p.WorkFlowNextStepId);
            }
            else if (Step.RecordType == WorkFlowStepType.Validation)
            {
                var Query = await UnitOfWork.ValidationSteps
                    .GetAsync(p => p.Id == Step.RecordId, p => p.Query);

                Query = await Query.FixPattern(DataSource);

                Result = await UnitOfWork.ValidationSteps
                   .CheckAsync(Query);

                DataSource.Add(new WorkFlowDataSource()
                {
                    Key = Step.Id.ToString(),
                    Value = Result,
                    Type = JTokenType.Boolean
                });

                if ((bool)Result)
                {
                    NextStepId = await UnitOfWork.ValidationStepTrues
                        .GetAsync(p => p.ValidationStepId == Step.RecordId, p => p.WorkFlowStepId);
                }
                else
                {
                    NextStepId = await UnitOfWork.ValidationStepFalses
                        .GetAsync(p => p.ValidationStepId == Step.RecordId, p => p.WorkFlowStepId);
                }
            }
            else if (Step.RecordType == WorkFlowStepType.ErrorMessage || Step.RecordType == WorkFlowStepType.SuccessMessage)
            {
                var MessageId = await UnitOfWork.MessageSteps
                    .GetAsync(p => p.Id == Step.RecordId, p => p.MessageId);

                var MessageText = await UnitOfWork.LangMessages
                    .GetMessageTextWithLangCodeAndMessageId(MessageId, "fa");

                MessageText = await MessageText.FixPattern(DataSource);

                DataSource.Add(new WorkFlowDataSource()
                {
                    Key = Step.RecordType == WorkFlowStepType.SuccessMessage ? Dnettec.Utility.Constance.SUCCESSMESSAGE : Dnettec.Utility.Constance.ERRORMESSAGE,
                    Value = MessageText,
                    Type = JTokenType.String
                });
            }

            if (NextStepId != Guid.Empty)
            {
                await RunWorkStep(DataSource, NextStepId);
            }
            else
            {
                var WorkFlowResponse = await UnitOfWork.WorkFlowResponses
                    .GetAsync(p => p.WorkFlowId == Step.WorkFlowId);

                if (WorkFlowResponse != null)
                {
                    var ResponseJData = (JObject)Newtonsoft.Json.JsonConvert
                        .DeserializeObject(WorkFlowResponse.ResponseJson);

                    await ResponseJData.Values().ToList().FixWorkFlowResponse(DataSource);

                    DataSource.Add(new WorkFlowDataSource()
                    {
                        Key = Dnettec.Utility.Constance.RESPONSEKEY,
                        Value = ResponseJData
                    });
                }
            }
        }
    }
}