using Kernel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.Applications.Repositories
{
    public interface IApplicationRepository
        : Dnettec.Persistence.Repositories.IRepository<Application>
    {

    }

    public class ApplicationRepository
        : Dnettec.Persistence.Repositories.Repository<Application>, IApplicationRepository
    {
        public ApplicationRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
