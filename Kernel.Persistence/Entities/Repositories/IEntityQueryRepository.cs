using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.Entities.Repositories
{
    public interface IEntityQueryRepository
        : Dnettec.Persistence.QueryRepositories.IQueryRepository<Domain.Models.Entity>
    {
    }
}
