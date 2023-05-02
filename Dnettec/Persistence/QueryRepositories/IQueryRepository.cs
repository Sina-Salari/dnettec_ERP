using Dnettec.Domain;
using System.Data;
using System.Linq.Expressions;

namespace Dnettec.Persistence.QueryRepositories
{
    public interface IQueryRepository<T> where T : IBaseEntity
	{
        Task<T> GetByIdAsync(Guid id);

        Task<IList<T>> GetAllAsync();

        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<TF> GetAsync<TF>(Expression<Func<T, bool>> where, Expression<Func<T, TF>> select);

        Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> where);
        Task<IList<TF>> GetManyAsync<TF>(Expression<Func<T, bool>> where, Expression<Func<T, TF>> select);

        Task<bool> GetAnyAsync(Expression<Func<T, bool>> where);
	}
}
