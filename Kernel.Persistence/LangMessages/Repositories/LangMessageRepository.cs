using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Reflection.Metadata;

namespace Kernel.Persistence.LangMessages.Repositories
{
    public class LangMessageRepository
    : Dnettec.Persistence.Repositories.Repository<Domain.Models.LangMessage>, ILangMessageRepository
    {
        public LangMessageRepository(DbContext databaseContext, SqlConnection dapperContext) : base(databaseContext)
        {
            DapperContext = dapperContext;
        }
        protected SqlConnection DapperContext { get; }

        public async Task<string> GetMessageTextWithLangCodeAndMessageId(Guid MessageId, string LangCode)
        {
            var Query = @"
                        select top 1 LangMessages.MessageText from LangMessages
                        inner join Languages on LangMessages.LanguageId = Languages.Id
                        inner join Messages on LangMessages.MessageId = Messages.Id
                        where MessageId = @MessageId and Languages.Code = @LangCode
                        ";

            var parameter = new DynamicParameters();
            parameter.Add(nameof(MessageId), MessageId);
            parameter.Add(nameof(LangCode), LangCode);

            var Response = await DapperContext.QueryAsync<string>(Query,parameter);

            if(Response == null)
            {
                return string.Empty;
            }

            return Response.FirstOrDefault();
        }
    }
}
