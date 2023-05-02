using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Persistence.ProcessSteps.Repositories
{
    public class ProcessStepRepository
        : Dnettec.Persistence.Repositories.Repository<Domain.Models.ProcessStep>, IProcessStepRepository
    {
        public ProcessStepRepository(DbContext databaseContext, SqlConnection dapperContext) : base(databaseContext)
        {
            DapperContext = dapperContext;
        }
        protected SqlConnection DapperContext { get; }

        public async Task<int> ExecuteAsync(string query,object parameter)
        {
            return await DapperContext.ExecuteAsync(query, parameter);
        }

        public async Task<int> ExecuteAsync(string query)
        {
            return await DapperContext.ExecuteAsync(query);
        }

        public async Task<dynamic> QueryAsync(string query,object parameter)
        {
            return await DapperContext.QueryAsync(query,parameter);
        }

        public async Task<dynamic> QueryAsync(string query)
        {
            return await DapperContext.QueryAsync(query);
        }
    }
}
