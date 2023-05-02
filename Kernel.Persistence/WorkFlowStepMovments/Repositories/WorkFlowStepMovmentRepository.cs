using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.WorkFlowStepMovments.Repositories
{
    public class WorkFlowStepMovmentRepository
        : Dnettec.Persistence.Repositories.Repository<Domain.Models.WorkFlowStepMovment>, IWorkFlowStepMovmentRepository
    {
        public WorkFlowStepMovmentRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
