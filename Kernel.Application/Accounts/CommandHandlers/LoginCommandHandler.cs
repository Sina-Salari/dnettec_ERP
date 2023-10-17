using AutoMapper;
using FluentResults;
using Kernel.Application.Accounts.Commands;
using Kernel.Persistence.Common.UnitOfWork;
using Kernel.ViewModel.Accounts.ViewModels;

namespace Kernel.Application.Accounts.CommandHandlers
{
    public class LoginCommandHandler
        : Dnettec.Mediator.IRequestHandler<LoginCommand, LoginCommandViewModel>
    {
        public LoginCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base()
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        protected IUnitOfWork UnitOfWork { get; }
        protected IMapper Mapper { get; }

        public async Task<Result<LoginCommandViewModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var Result = new Result<LoginCommandViewModel>();

            var Account = await UnitOfWork.Accounts
                .GetAsync(p => p.UserName == request.UserName.Trim());

            if (Account is null)
            {
                Result
                    .WithError(string.Format(Resources.Messages.Errors.NotFound, Resources.DataDictionary.UserName));
                return Result;
            }

            var HashPass = request.Password
                .HashWithSalt(Guid.Parse(Account.PasswordSalt));

            if (Account.Password != HashPass)
            {
                Result
                    .WithError(string.Format(Resources.Messages.Errors.NotFound, Resources.DataDictionary.UserName));
                return Result;
            }

            var Application = await UnitOfWork.Applications
                .GetAsync(p => p.Id == Account.ApplicationId);

            var token = Account.Id
                .GenarateToken(Application.TokenKey, Application.TokenTimeOut);

            LoginCommandViewModel Data = new LoginCommandViewModel
            {
                Token = token,
            };

            Result
                .WithSuccess(string.Format(Resources.Messages.Successes.OprationSuccess, Resources.DataDictionary.Login));
            Result
                .WithValue(Data);

            return Result;
        }
    }
}
