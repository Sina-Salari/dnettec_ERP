using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace Kernel.Persistence.ValidationSteps.Repositories
{
    public class ValidationStepsRepository
        : Dnettec.Persistence.Repositories.Repository<Domain.Models.ValidationStep>, IValidationStepsRepository
    {
        public ValidationStepsRepository(DbContext databaseContext, SqlConnection sqlConnection) : base(databaseContext)
        {
            DapperContext = sqlConnection;
        }

        protected SqlConnection DapperContext { get; }

        public async Task<bool> CheckAsync(string query)
        {
            var Result = await DapperContext.QueryAsync<int>(query);
            return Result.FirstOrDefault() == 1 ? true : false;
        }
    }
}
