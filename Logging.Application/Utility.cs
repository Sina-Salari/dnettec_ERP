using FluentResults;
using FluentValidation;
using FluentValidation.Results;

namespace Logging.Application
{
    internal static class Utility
    {
        static Utility()
        {
        }

        public static async Task<Result<TValue>> Validate<TCommand, TValue>(AbstractValidator<TCommand> validator, TCommand command)
        {
            Result<TValue> result = new Result<TValue>();

            ValidationResult validationResult = await validator.ValidateAsync(instance: command);

            if (validationResult.IsValid == false)
            {
                foreach (var error in validationResult.Errors)
                {
                    result.WithError(errorMessage: error.ErrorMessage);
                }
            }

            return result;
        }
    }
}
