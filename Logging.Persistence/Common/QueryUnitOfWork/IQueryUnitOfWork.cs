using Logging.Persistence.Logs.Repositories;

namespace Logging.Persistence.Common.QueryUnitOfWork
{
	public interface IQueryUnitOfWork : Dnettec.Persistence.QueryUnitOfWork.IQueryUnitOfWork
	{
		public ILogQueryRepository Logs { get; }
	}
}
