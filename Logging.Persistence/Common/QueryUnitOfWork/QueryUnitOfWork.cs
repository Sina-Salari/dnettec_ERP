using Logging.Persistence.Common.Context;
using Logging.Persistence.Logs.Repositories;

namespace Logging.Persistence.Common.QueryUnitOfWork
{
    public class QueryUnitOfWork : Dnettec.Persistence.QueryUnitOfWork.QueryUnitOfWork<QueryDatabaseContext>, IQueryUnitOfWork
    {
        public QueryUnitOfWork(Dnettec.Persistence.Common.Options options) : base(options: options)
        {
        }

        // **************************************************
        private ILogQueryRepository _logs;

        public ILogQueryRepository Logs
        {
            get
            {
                if (_logs == null)
                {
                    _logs = new LogQueryRepository(DatabaseContext);
                }

                return _logs;
            }
        }
        // **************************************************
    }
}
