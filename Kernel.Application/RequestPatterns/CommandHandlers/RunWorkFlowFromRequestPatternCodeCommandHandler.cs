using AutoMapper;
using Dnettec.Logging;
using FluentResults;
using Kernel.Application.RequestPatterns.Commands;
using Kernel.Persistence.Common.UnitOfWork;
using Kernel.ViewModel.Common;
using Kernel.ViewModel.RequestPatterns.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Application.RequestPatterns.CommandHandlers
{
    public class RunWorkFlowFromRequestPatternCodeCommandHandler
        : Dnettec.Mediator.IRequestHandler<RunWorkFlowFromRequestPatternCodeCommand, RunWorkFlowFromRequestPatternCodeCommandResponseViewModel>
    {
        public RunWorkFlowFromRequestPatternCodeCommandHandler(
            ILogger<RunWorkFlowFromRequestPatternCodeCommandHandler> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork) : base()
        {
            Logger = logger;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }
        protected ILogger<RunWorkFlowFromRequestPatternCodeCommandHandler> Logger { get; }


        public async Task<Result<RunWorkFlowFromRequestPatternCodeCommandResponseViewModel>> Handle(RunWorkFlowFromRequestPatternCodeCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<RunWorkFlowFromRequestPatternCodeCommandResponseViewModel>();

            var Pattern = await UnitOfWork.RequestPatterns
                .GetAsync(p => p.Controller == request.Controller && p.Action == request.Action);

            if (Pattern == null)
            {
                result.WithError(String.Format(Resources.Messages.Errors.NotFound, Resources.DataDictionary.EndPoint));
                return result;
            }

            var WorkFlowInput = await UnitOfWork.WorkFlowInputs
                .GetAsync(p => p.WorkFlowId == Pattern.WorkFlowId);

            var JPatternBody = (JObject)Newtonsoft.Json.JsonConvert
                .DeserializeObject(WorkFlowInput.BodyJson);

            var JRequestBody = (JObject)Newtonsoft.Json.JsonConvert
                .DeserializeObject(request.JsonBody.ToString());

            var RequestDataSource = new List<WorkFlowDataSource>();
            await RequestDataSource.MapJsonToDataSource(JRequestBody.Values().ToList());

            var DataSource = new List<WorkFlowDataSource>();
            await DataSource.MapJsonToDataSource(JPatternBody.Values().ToList());

            foreach (var item in DataSource)
            {
                var Data = RequestDataSource
                    .Where(p => p.Key == item.Key)
                    .FirstOrDefault();

                if (Data == null)
                {
                    result.WithError(string.Format(Resources.Messages.Validations.Required, item.Key));
                    return result;
                }

                if (Data.Type != item.Type)
                {
                    result.WithError(string.Format(Resources.Messages.Validations.RegularExpression, item.Key));
                    return result;
                }

                item.Value = Data.Value;
            }

            result.WithValue(new RunWorkFlowFromRequestPatternCodeCommandResponseViewModel()
            {
                WorkFlowId = Pattern.WorkFlowId,
                DataSource = DataSource
            });

            return result;
        }
    }
}
