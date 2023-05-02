using Microsoft.AspNetCore.Mvc;

namespace Kernel.Api.Infrastructure
{
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
}
