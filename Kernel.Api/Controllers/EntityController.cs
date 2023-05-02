using Kernel.Application.Entities.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Api.Controllers
{
    public class EntityController : Infrastructure.ControllerBase
    {
        public EntityController(IMediator mediator) : base(mediator)
        {
        }


        [HttpGet]
        [ProducesResponseType(
            typeof(FluentResults.Result<Guid>),
            StatusCodes.Status200OK
            )]
        [ProducesResponseType(
            typeof(FluentResults.Result),
            StatusCodes.Status400BadRequest
            )]
        public async Task<IActionResult> Insert([FromBody] InsertEntityCommand request)
        {
            return FluentResult(await Mediator.Send(request));
        }
    }
}
