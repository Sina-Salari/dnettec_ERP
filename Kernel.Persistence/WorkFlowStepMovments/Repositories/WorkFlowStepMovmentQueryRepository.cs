using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.WorkFlowStepMovments.Repositories
{
    public class WorkFlowStepMovmentQueryRepository
        : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.WorkFlowStepMovment>, IWorkFlowStepMovmentQueryRepository
    {
        public WorkFlowStepMovmentQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
