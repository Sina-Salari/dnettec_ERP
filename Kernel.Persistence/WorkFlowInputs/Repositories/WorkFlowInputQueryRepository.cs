using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.WorkFlowInputs.Repositories
{
    public class WorkFlowInputQueryRepository
        : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.WorkFlowInput>, IWorkFlowInputQueryRepository
    {
        public WorkFlowInputQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
