using FluentValidation;

namespace Kernel.Application.Accounts.Commands
{
    public class LoginCommandValidation
        : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidation() : base()
        {
            RuleFor(p => p.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(Resources.Messages.Validations.Required, Resources.DataDictionary.UserName));

            RuleFor(p => p.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(Resources.Messages.Validations.Required, Resources.DataDictionary.Password));

            RuleFor(p => p.Password)
                .Matches(@"[0-9]+")
                .WithMessage(string.Format(Resources.Messages.Validations.PasswordMustInclude, Resources.DataDictionary.Number));

            RuleFor(p => p.Password)
                .Matches(@"[A-Z]+")
                .WithMessage(string.Format(Resources.Messages.Validations.PasswordMustInclude, Resources.DataDictionary.CapitalLetter));

            RuleFor(p => p.Password)
                .Matches(@".{8,}")
                .WithMessage(string.Format(Resources.Messages.Validations.MinLength, Resources.DataDictionary.Password, 8));
        }
    }
}
