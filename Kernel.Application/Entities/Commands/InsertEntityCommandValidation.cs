using FluentValidation;

namespace Kernel.Application.Entities.Commands
{
    public class InsertEntityCommandValidation
        : AbstractValidator<InsertEntityCommand>
    {
        public InsertEntityCommandValidation() : base()
        {
            RuleFor(p => p.EntityName)
                .NotEmpty()
                .WithMessage(string.Format(Resources.Messages.Validations.Required, Resources.DataDictionary.EntityName));

            RuleFor(p => p.IsBase)
                .Must(p => p == true || p == false)
                .WithMessage(string.Format(Resources.Messages.Validations.Required, Resources.DataDictionary.EntityName));
        }
    }
}
