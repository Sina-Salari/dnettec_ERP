using Kernel.ViewModel.Accounts.ViewModels;

namespace Kernel.Application.Accounts.Commands
{
    public class LoginCommand
        : Dnettec.Mediator.IRequest<LoginCommandViewModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
