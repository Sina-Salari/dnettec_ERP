using Kernel.Persistence.Common.Context;
using Microsoft.Data.SqlClient;

namespace Kernel.Persistence.Common.QueryUnitOfWork
{
    public class QueryUnitOfWork :
        Dnettec.Persistence.QueryUnitOfWork.QueryUnitOfWork<QueryDatabaseContext>, IQueryUnitOfWork
    {
        protected SqlConnection DapperContext { get; }
        public QueryUnitOfWork
            (Dnettec.Persistence.Common.Options options) : base(options: options)
        {
            DapperContext = new SqlConnection(Options.ConnectionString);
        }


        // **************************************************
        private Entities.Repositories.IEntityQueryRepository _entities;

        public Entities.Repositories.IEntityQueryRepository Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities =
                        new Entities.Repositories.EntityQueryRepository(DatabaseContext);
                }

                return _entities;
            }
        }
        // **************************************************

        // **************************************************
        private RequestPatterns.Repositories.IRequestPatternQueryRepository _requestPatterns;

        public RequestPatterns.Repositories.IRequestPatternQueryRepository RequestPatterns
        {
            get
            {
                if (_requestPatterns == null)
                {
                    _requestPatterns =
                        new RequestPatterns.Repositories.RequestPatternQueryRepository(DatabaseContext);
                }

                return _requestPatterns;
            }
        }
        // **************************************************

        // **************************************************
        private WorkFlowSteps.Repositories.IWorkFlowStepQueryRepository _workFlowSteps;

        public WorkFlowSteps.Repositories.IWorkFlowStepQueryRepository WorkFlowSteps
        {
            get
            {
                if (_workFlowSteps == null)
                {
                    _workFlowSteps =
                        new WorkFlowSteps.Repositories.WorkFlowStepQueryRepository(DatabaseContext);
                }

                return _workFlowSteps;
            }
        }
        // **************************************************

        // **************************************************
        private WorkFlowStepMovments.Repositories.IWorkFlowStepMovmentQueryRepository _workFlowStepMovments;

        public WorkFlowStepMovments.Repositories.IWorkFlowStepMovmentQueryRepository WorkFlowStepMovments
        {
            get
            {
                if (_workFlowStepMovments == null)
                {
                    _workFlowStepMovments =
                        new WorkFlowStepMovments.Repositories.WorkFlowStepMovmentQueryRepository(DatabaseContext);
                }

                return _workFlowStepMovments;
            }
        }
        // **************************************************

        // **************************************************
        private ProcessSteps.Repositories.IProcessStepQueryRepository _processSteps;

        public ProcessSteps.Repositories.IProcessStepQueryRepository ProcessSteps
        {
            get
            {
                if (_processSteps == null)
                {
                    _processSteps =
                        new ProcessSteps.Repositories.ProcessStepQueryRepository(DatabaseContext);
                }

                return _processSteps;
            }
        }
        // **************************************************
    }
}
