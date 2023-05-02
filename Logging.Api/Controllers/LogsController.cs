using Logging.Application.Logs.Commands;
using Logging.Application.Logs.Queries;
using Logging.Persistence.Logs.ViewModels;
using Kernel.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Api.Controllers
{
    [ApiController]
    [Route(template: Constant.Router.Controller)]
    public class LogsController : Infrastructure.ControllerBase
    {
        public LogsController(IMediator mediator) : base(mediator: mediator)
        {
        }

        #region Post (Create Log)
        [ProducesResponseType(
            type: typeof(FluentResults.Result<Guid>),
            statusCode: StatusCodes.Status200OK
            )]
        [ProducesResponseType(
            type: typeof(FluentResults.Result),
            statusCode: StatusCodes.Status400BadRequest
            )]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLogCommand request)
        {
            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Post (Create Log)

        #region Get (Get Some Logs)
        [ProducesResponseType(
            type: typeof(FluentResults.Result<IList<GetLogsQueryResponseViewModel>>),
            statusCode: StatusCodes.Status200OK
            )]
        [ProducesResponseType(
            type: typeof(FluentResults.Result),
            statusCode: StatusCodes.Status400BadRequest
            )]
        [HttpGet(template: "{count?}")]
        public async Task<IActionResult> Get([FromRoute] int? count)
        {
            var request = new GetLogsQuery
            {
                Count = count,
            };

            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Get (Get Some Logs)
    }
}
