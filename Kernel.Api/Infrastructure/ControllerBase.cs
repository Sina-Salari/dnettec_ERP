using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Api.Infrastructure
{
    [Authorize]
    [ApiController]
    [Route(Constant.Router.Controller)]
    public abstract class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected ControllerBase(MediatR.IMediator mediator) : base()
        {
            Mediator = mediator;
        }

        protected MediatR.IMediator Mediator { get; }

        protected IActionResult FluentResult<T>
            (FluentResults.Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(value: result);
            }
            else
            {
                return BadRequest(error: result.ToResult());
            }
        }

        protected IActionResult FluentResult
            (FluentResults.Result result)
        {
            if (result.IsSuccess)
            {
                return Ok(value: result);
            }
            else
            {
                return BadRequest(error: result);
            }
        }
    }

    //[Authorize]
    [ApiController]
    [Route(Constant.Router.DynamicController)]
    public abstract class DynamicControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected DynamicControllerBase(MediatR.IMediator mediator) : base()
        {
            Mediator = mediator;
        }

        protected MediatR.IMediator Mediator { get; }

        protected IActionResult FluentResult<T>
            (FluentResults.Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(value: result);
            }
            else
            {
                return BadRequest(error: result.ToResult());
            }
        }

        protected IActionResult FluentResult
            (FluentResults.Result result)
        {
            if (result.IsSuccess)
            {
                return Ok(value: result);
            }
            else
            {
                return BadRequest(error: result);
            }
        }
    }
}
