using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Kernel.Persistence.Common.Context
{
    public class DapperDatabaseContext
    {
        public DapperDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration;

        public SqlConnection CreateConnection()
            => new SqlConnection(_configuration.GetConnectionString("CommandsConnectionString"));

        public SqlConnection CreateMasterConnection()
            => new SqlConnection(_configuration.GetConnectionString("MasterConnection"));

        public async Task ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var Connection = CreateConnection())
            {
                await Connection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
            }
        }

        public async Task<string> QueryAsync(string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (var Connection = CreateConnection())
            {
                var Result = await Connection.QueryAsync(sql, param, transaction, commandTimeout, commandType);
                return Newtonsoft.Json.JsonConvert.SerializeObject(Result);
            }
        }

        public string GetDBName()
            => _configuration["dbName"];
    }
}
