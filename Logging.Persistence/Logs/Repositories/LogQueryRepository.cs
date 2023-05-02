using Logging.Domain.Models;
using Logging.Persistence.Common.Context;
using Logging.Persistence.Logs.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Logging.Persistence.Logs.Repositories
{
	public class LogQueryRepository : Dnettec.Persistence.QueryRepositories.QueryRepository<Log>, ILogQueryRepository
	{

        public LogQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<IList<GetLogsQueryResponseViewModel>>GetSomeAsync(int count)
		{
			var result = await DbSet
				.OrderByDescending(current => current.TimeStamp)
				.Skip(count: 0)
				.Take(count: count)
				.Select(current => new GetLogsQueryResponseViewModel()
				{
					Id = current.Id,
					Level = current.Level,
					TimeStamp = current.TimeStamp,

					Message = current.Message,

					ApplicationName = current.ApplicationName,
					Namespace = current.Namespace,
					ClassName = current.ClassName,
					MethodName = current.MethodName,

					RemoteIP = current.RemoteIP,
					Username = current.Username,
					RequestPath = current.RequestPath,
				}).ToListAsync();

			return result;
		}
	}
}
