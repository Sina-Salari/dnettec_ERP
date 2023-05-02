using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.WorkFlowSteps.Repositories
{
    public class WorkFlowStepQueryRepository
    : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.WorkFlowStep>, IWorkFlowStepQueryRepository
    {
        public WorkFlowStepQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
