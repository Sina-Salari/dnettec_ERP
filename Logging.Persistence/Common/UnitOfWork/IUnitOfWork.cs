using Logging.Persistence.Logs.Repositories;

namespace Logging.Persistence.Common.UnitOfWork
{
	public interface IUnitOfWork : Dnettec.Persistence.UnitOfWork.IUnitOfWork
	{
		public ILogRepository Logs { get; }
	}
}
