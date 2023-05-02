using Logging.Persistence.Common.Context;
using Logging.Persistence.Logs.Repositories;

namespace Logging.Persistence.Common.UnitOfWork
{
	public class UnitOfWork : Dnettec.Persistence.UnitOfWork.UnitOfWork<DatabaseContext>, IUnitOfWork
	{
		public UnitOfWork(Dnettec.Persistence.Common.Options options) : base(options: options)
		{
		}

		// **************************************************
		private ILogRepository _logs;

		public ILogRepository Logs
		{
			get
			{
				if (_logs == null)
				{
					_logs = new LogRepository(DatabaseContext);
				}

				return _logs;
			}
		}
		// **************************************************
	}
}
