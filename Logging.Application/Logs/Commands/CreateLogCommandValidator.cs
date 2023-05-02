﻿using FluentValidation;

namespace Logging.Application.Logs.Commands
{
	public class CreateLogCommandValidator : AbstractValidator<CreateLogCommand>
	{
		public CreateLogCommandValidator() : base()
		{
			RuleFor(current => current.ApplicationName)
				.NotEmpty()
				.WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)

				.MaximumLength(maximumLength: 100)
				.WithMessage(errorMessage: Resources.Messages.ErrorMaximumLength)
				;

			RuleFor(current => current.Namespace)
				.NotEmpty()
				.WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)

				.MaximumLength(maximumLength: 100)
				.WithMessage(errorMessage: Resources.Messages.ErrorMaximumLength)
				;

			RuleFor(current => current.ClassName)
				.NotEmpty()
				.WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)

				.MaximumLength(maximumLength: 100)
				.WithMessage(errorMessage: Resources.Messages.ErrorMaximumLength)
				;

			RuleFor(current => current.MethodName)
				.NotEmpty()
				.WithMessage(errorMessage: Resources.Messages.ErrorRequiredFluent)

				.MaximumLength(maximumLength: 100)
				.WithMessage(errorMessage: Resources.Messages.ErrorMaximumLength)
				;

			RuleFor(current => current.RemoteIP)
				.MaximumLength(maximumLength: 15)
				.WithMessage(errorMessage: Resources.Messages.ErrorMaximumLength)
				;

			RuleFor(current => current.Username)
				.MaximumLength(maximumLength: 50)
				.WithMessage(errorMessage: Resources.Messages.ErrorMaximumLength)
				;

			RuleFor(current => current.RequestPath)
				.MaximumLength(maximumLength: 200)
				.WithMessage(errorMessage: Resources.Messages.ErrorMaximumLength)
				;
		}
	}
}
