using Logging.Domain.Models;
using Logging.Persistence.Logs.ViewModels;

namespace Logging.Persistence.Logs.Repositories
{
	public interface ILogQueryRepository : Dnettec.Persistence.QueryRepositories.IQueryRepository<Log>
	{
		Task<IList<GetLogsQueryResponseViewModel>>GetSomeAsync(int count);
	}
}
