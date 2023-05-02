using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.ProcessSteps.Repositories
{
    public class ProcessStepQueryRepository
    : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.ProcessStep>, IProcessStepQueryRepository
    {
        public ProcessStepQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
