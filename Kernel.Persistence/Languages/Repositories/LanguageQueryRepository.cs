using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.Languages.Repositories
{
    public class LanguageQueryRepository
    : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.Language>, ILanguageQueryRepository
    {
        public LanguageQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
