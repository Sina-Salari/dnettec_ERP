using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.WorkFlowResponses.Repositories
{
    public class WorkFlowResponsesRepository
        : Dnettec.Persistence.Repositories.Repository<Domain.Models.WorkFlowResponse>, IWorkFlowResponsesRepository
    {
        public WorkFlowResponsesRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
