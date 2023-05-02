using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.WorkFlowInputs.Repositories
{
    public class WorkFlowInputRepository
    : Dnettec.Persistence.Repositories.Repository<Domain.Models.WorkFlowInput>, IWorkFlowInputRepository
    {
        public WorkFlowInputRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
