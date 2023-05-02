using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.Languages.Repositories
{
    public interface ILanguageRepository
        : Dnettec.Persistence.Repositories.IRepository<Domain.Models.Language>
    {
    }
}
