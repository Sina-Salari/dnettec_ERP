using Kernel.Application.RequestPatterns.Commands;
using Kernel.Application.WorkFlows.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Api.Controllers
{
    public class ApiController : Infrastructure.ControllerBase
    {
        public ApiController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("{paramOne}/{paramTwo}")]
        public async Task<IActionResult> Post(string paramOne, string paramTwo, [FromBody] dynamic body)
        {
            var RunWorkFlowFromRequestPatternCodeCommandResponse = await Mediator
                .Send(new RunWorkFlowFromRequestPatternCodeCommand()
                {
                    Controller = paramOne.ToUpper(),
                    Action = paramTwo.ToUpper(),
                    JsonBody = body
                });

            if (RunWorkFlowFromRequestPatternCodeCommandResponse.IsFailed)
            {
                return FluentResult(RunWorkFlowFromRequestPatternCodeCommandResponse);
            }

            var result = await Mediator
                .Send(new RunWorkFlowCommand()
                {
                    WorkFlowId = RunWorkFlowFromRequestPatternCodeCommandResponse.Value.WorkFlowId,
                    DataSource = RunWorkFlowFromRequestPatternCodeCommandResponse.Value.DataSource
                });

            return FluentResult(result);
        }
    
        [HttpPost]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}
