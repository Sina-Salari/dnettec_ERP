using Dnettec.Mediator;
using Dnettec.Logging;
using AutoMapper;
using FluentResults;
using Logging.Persistence.Common.UnitOfWork;
using Logging.Resources;
using Logging.Application.Logs.Commands;

namespace Logging.Application.Logs.CommandHandlers
{
	public class CreateLogCommandHandler : IRequestHandler<CreateLogCommand, Guid>
	{
		public CreateLogCommandHandler(
			ILogger<CreateLogCommandHandler> logger,
			IMapper mapper,
			IUnitOfWork unitOfWork) : base()
		{
			Logger = logger;
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected IMapper Mapper { get; }

		protected IUnitOfWork UnitOfWork { get; }

		protected ILogger<CreateLogCommandHandler> Logger { get; }

		public async Task<Result<Guid>> Handle(CreateLogCommand request, CancellationToken cancellationToken)
		{
			var result =
				new Result<System.Guid>();

			try
			{
				// **************************************************
				var log = Mapper.Map<Domain.Models.Log>(source: request);
				// **************************************************

				// **************************************************
				await UnitOfWork.Logs.InsertAsync(entity: log);

				await UnitOfWork.SaveAsync();
				// **************************************************

				// **************************************************
				result.WithValue(value: log.Id);

				string successInsert =
					string.Format(Messages.SuccessInsert, nameof(Log));

				result.WithSuccess
					(successMessage: successInsert);
				// **************************************************
			}
			catch (System.Exception ex)
			{
				Logger.LogError
					(exception: ex, message: ex.Message);

				result.WithError
					(errorMessage: ex.Message);
			}

			return result;
		}
	}
}
