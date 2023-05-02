using Kernel.Persistence.Common.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.Entities.Repositories
{
    public class EntityQueryRepository
        : Dnettec.Persistence.QueryRepositories.QueryRepository<Domain.Models.Entity>, IEntityQueryRepository
    {
        public EntityQueryRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
