using Dnettec.Domain;
using Dnettec.Persistence.QueryRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnettec.Persistence.Repositories
{
    public interface IRepository<T> : IQueryRepository<T> where T : IBaseEntity
	{
		Task InsertAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(T entity);

		Task<bool> DeleteByIdAsync(Guid id);
	}
}
