using Logging.Persistence.Logs.ViewModels;

namespace Logging.Application.Logs.Queries
{
	public class GetLogsQuery : Dnettec.Mediator.IRequest<IEnumerable<GetLogsQueryResponseViewModel>>
	{
		public GetLogsQuery() : base()
		{
		}

		public int? Count { get; set; }
	}
}
