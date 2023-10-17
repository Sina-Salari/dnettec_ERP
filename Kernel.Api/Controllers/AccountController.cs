using Kernel.Application.Accounts.Commands;
using Kernel.ViewModel.Accounts.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kernel.Api.Controllers
{
    public class AccountController : Infrastructure.ControllerBase
    {
        public AccountController(IMediator mediator) : base(mediator)
        {
        }

        [ProducesResponseType(
            typeof(FluentResults.Result<LoginCommandViewModel>),
            StatusCodes.Status200OK
            )]
        [ProducesResponseType(
            typeof(FluentResults.Result),
            StatusCodes.Status400BadRequest
            )]
        [AllowAnonymous]
        [HttpPost("LoginByPassword")]
        public async Task<IActionResult> LoginByPassword([FromBody] LoginCommand command)
        {
            return FluentResult(await Mediator.Send(command));
        }
    }
}