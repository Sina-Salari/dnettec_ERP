using Dapper;
using Kernel.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.Entities.Repositories
{
    public class EntityRepository
        : Dnettec.Persistence.Repositories.Repository<Entity>, IEntityRepository
    {
        public EntityRepository(DbContext databaseContext, SqlConnection dapperContext) : base(databaseContext)
        {
            DapperContext = dapperContext;
        }
        protected SqlConnection DapperContext { get; }

        public override async Task InsertAsync(Entity entity)
        {
            var Qurey =
                @$"CREATE TABLE {entity.EntityName} (
                       Id uniqueidentifier,
                       IsDeleted bit
                )";

            await DapperContext.ExecuteAsync(Qurey);
            await base.InsertAsync(entity);
        }

        public override async Task UpdateAsync(Entity entity)
        {
            var LastName = await GetAsync(p => p.Id == entity.Id, p => p.EntityName);

            var Qurey =
                $"RENAME {LastName} TO {entity.EntityName};";

            await DapperContext.ExecuteAsync(Qurey);
            await base.UpdateAsync(entity);
        }
    }
}
