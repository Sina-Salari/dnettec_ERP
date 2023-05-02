using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.WorkFlowResponses.Repositories
{
    public class WorkFlowResponsesQueryRepository
        : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.WorkFlowResponse>, IWorkFlowResponsesQueryRepository
    {
        public WorkFlowResponsesQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
