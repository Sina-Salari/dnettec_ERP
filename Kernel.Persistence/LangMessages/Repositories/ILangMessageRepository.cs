using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.LangMessages.Repositories
{
    public interface ILangMessageRepository
        : Dnettec.Persistence.Repositories.IRepository<Domain.Models.LangMessage>
    {
        Task<string> GetMessageTextWithLangCodeAndMessageId(Guid MessageId, string LangCode);
    }
}
