using AutoMapper;
using FluentResults;
using Logging.Application.Logs.Queries;
using Logging.Persistence.Common.QueryUnitOfWork;
using Logging.Persistence.Logs.ViewModels;

namespace Logging.Application.Logs.CommandHandlers
{
	public class GetLogsQueryHandler : Dnettec.Mediator.IRequestHandler<GetLogsQuery, IEnumerable<GetLogsQueryResponseViewModel>>
	{
		public GetLogsQueryHandler
			(Dnettec.Logging.ILogger<CreateLogCommandHandler> logger,
			IMapper mapper,
			IQueryUnitOfWork unitOfWork) : base()
		{
			Logger = logger;
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected IMapper Mapper { get; }

		protected IQueryUnitOfWork UnitOfWork { get; }

		protected Dnettec.Logging.ILogger<CreateLogCommandHandler> Logger { get; }

		public async Task<Result<IEnumerable<GetLogsQueryResponseViewModel>>>Handle(GetLogsQuery request, System.Threading.CancellationToken cancellationToken)
		{
			var result = new Result
				<IEnumerable<GetLogsQueryResponseViewModel>>();

			try
			{
				// **************************************************
				var logs = await UnitOfWork.Logs
					.GetSomeAsync(count: request.Count.Value);
				// **************************************************

				// **************************************************
				result.WithValue(value: logs);
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
