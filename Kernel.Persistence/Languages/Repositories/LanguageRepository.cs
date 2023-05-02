using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.Languages.Repositories
{
    public class LanguageRepository
        : Dnettec.Persistence.Repositories.Repository<Domain.Models.Language>, ILanguageRepository
    {
        public LanguageRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
