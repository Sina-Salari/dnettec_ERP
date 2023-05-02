using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.LangMessages.Repositories
{
    public class LangMessageQueryRepository
        : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.LangMessage>, ILangMessageQueryRepository
    {
        public LangMessageQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
