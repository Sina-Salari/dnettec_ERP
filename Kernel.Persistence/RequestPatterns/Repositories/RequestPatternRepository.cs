using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.RequestPatterns.Repositories
{
    public class RequestPatternRepository
        : Dnettec.Persistence.Repositories.Repository<Domain.Models.RequestPattern>, IRequestPatternRepository
    {
        public RequestPatternRepository(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
