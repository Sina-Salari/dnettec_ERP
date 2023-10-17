using Dapper;
using Kernel.Domain.Enums;
using Kernel.Domain.Models.Base;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;

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
            => new SqlConnection(_configuration.GetConnectionString("CommandConnectionString"));

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

        public async Task<bool> CreateDatabaseAsync()
        {
            var dbName = GetDBName();
            var query = "SELECT * FROM sys.databases WHERE name = @name";
            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);
            var result = await QueryAsync(query, parameters);

            if (!result.Any())
                await ExecuteAsync($"CREATE DATABASE {dbName}");
            else
                return false;

            return true;
        }

        public async Task<bool> CreateTableAsync(string Name)
        {
            List<Tuple<string, string>> Fields = new List<Tuple<string, string>>();

            var Qurey = $"CREATE TABLE {Name} (";
            foreach (var field in await GetBaseField(Fields))
            {
                Qurey += $" {field.Item1} {field.Item2},";
            }
            Qurey += " )";

            await ExecuteAsync(Qurey);

            return true;
        }

        public async Task<bool> DropTableAsync(string Name)
        {
            var Query = $"DROP TABLE {Name};";
            await ExecuteAsync(Query);
            return true;
        }

        public async Task<bool> AlterTableAsync(string Name, string ReName)
        {
            var Query = $"ALTER {Name} RENAME TO {ReName};";
            await ExecuteAsync(Query);
            return true;
        }

        public async Task<bool> CreateColumnAsync(string Table, string Column, string DataType)
        {
            var Query = $"ALTER TABLE {Table} ADD {Column} {DataType};";
            await ExecuteAsync(Query);
            return true;
        }

        public async Task<bool> DropColumnAsync(string Table, string Column)
        {
            var Query = $"ALTER TABLE {Table} DROP COLUMN {Column};";
            await ExecuteAsync(Query);
            return true;
        }

        /// <summary>
        /// Get Base Field => item 1 : Name & item2 : type
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        private async Task<List<Tuple<string, string>>> GetBaseField(List<Tuple<string, string>> Model)
        {
            var BaseEntites = Assembly.GetAssembly(typeof(BaseEntity)).GetTypes()
                .Where(p => p.Name == Constants.BaseEntity).Single();

            foreach (var field in BaseEntites.GetProperties())
            {
                var Type = "";
                var SystemType = field.GetGetMethod().ReturnType.FullName;
                if (SystemType.Contains(Constants.Int))
                {
                    Type = Constants.Int;
                }
                else if (SystemType.Contains(Constants.Guid))
                {
                    Type = Constants.uniqueidentifier;
                }
                else if (SystemType.Contains(Constants.Boolean))
                {
                    Type = Constants.bit;
                }
                else if (SystemType.Contains(Constants.DateTime))
                {
                    Type = Constants.datetime2;
                }
                else if(SystemType.Contains(Constants.Enum))
                {
                    Type = Constants.Int;
                }
                Model.Add(Tuple.Create(field.Name, Type));
            }

            return Model;
        }
    }
}
