using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.RequestPatterns.Repositories
{
    public class RequestPatternQueryRepository
        : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.RequestPattern>, IRequestPatternQueryRepository
    {
        public RequestPatternQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
