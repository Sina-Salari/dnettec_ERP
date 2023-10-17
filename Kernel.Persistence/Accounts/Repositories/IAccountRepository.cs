using Kernel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kernel.Persistence.Accounts.Repositories
{
    public interface IAccountRepository
        : Dnettec.Persistence.Repositories.IRepository<Account>
    {

    }

    public class AccountRepositrory
        : Dnettec.Persistence.Repositories.Repository<Account>, IAccountRepository
    {
        public AccountRepositrory(DbContext databaseContext) : base(databaseContext)
        {
        }
    }
}
