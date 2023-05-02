using Dnettec.Persistence.Common;
using Dnettec.Persistence.QueryUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Dnettec.Persistence.UnitOfWork
{
    public abstract class UnitOfWork<T> : QueryUnitOfWork<T>, IUnitOfWork where T : DbContext
	{
		public UnitOfWork(Options options) : base(options: options)
		{
		}

		public async Task SaveAsync()
		{
			await DatabaseContext.SaveChangesAsync();
		}
	}
}
