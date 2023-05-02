using FluentValidation;
using MediatR;

namespace Dnettec.Mediator
{
    public class ValidationBehavior<TRequest, TResponse> : object, IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            Validators = validators;
        }

        protected IEnumerable<IValidator<TRequest>> Validators { get; }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (Validators.Any())
            {
                var context =
                    new ValidationContext<TRequest>(request);

                var validationResults =
                    await Task.WhenAll
                    (Validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures =
                    validationResults
                    .SelectMany(current => current.Errors)
                    .Where(current => current != null)
                    .ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(errors: failures);
                }
            }

            return await next();
        }
    }
}
