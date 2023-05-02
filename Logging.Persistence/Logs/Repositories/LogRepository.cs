using Logging.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Logging.Persistence.Logs.Repositories
{
	public class LogRepository : Dnettec.Persistence.Repositories.Repository<Log>, ILogRepository
	{
		protected internal LogRepository(DbContext databaseContext) : base(databaseContext)
		{
		}
	}
}
