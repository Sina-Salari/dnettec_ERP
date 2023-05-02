using Dnettec.Persistence.QueryUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnettec.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IQueryUnitOfWork
	{
		Task SaveAsync();
	}
}
