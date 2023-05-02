using Dapper;
using Dnettec.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace Dnettec.Persistence.QueryRepositories
{
    public abstract class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class,Domain.IBaseEntity
	{
		protected QueryRepository
			(DbContext databaseContext) : base()
		{
			DatabaseContext =
				databaseContext ??
				throw new System.ArgumentNullException(paramName: nameof(databaseContext));

			DbSet = DatabaseContext.Set<TEntity>();
		}

		// **********
		protected DbSet<TEntity> DbSet { get; }
		// **********

		// **********
		protected DbContext DatabaseContext { get; }
		// **********

		public virtual async Task<TEntity> GetByIdAsync(System.Guid id)
		{
			return await DbSet
				.FindAsync(keyValues: id);
		}

		public virtual async Task<IList<TEntity>> GetAllAsync()
		{
			// ToListAsync -> Extension Method -> using Microsoft.EntityFrameworkCore;
			var result = await DbSet
				.ToListAsync();

			return result;
		}

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
			return await DbSet
				.Where(where)
				.FirstOrDefaultAsync();
        }

        public virtual async Task<TF> GetAsync<TF>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TF>> select)
        {
			return await DbSet
				.Where(where)
				.Select(select)
				.FirstOrDefaultAsync();
		}

        public virtual async Task<IList<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
			return await DbSet
				.Where(where)
				.ToListAsync();
		}

        public virtual async Task<IList<TF>> GetManyAsync<TF>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TF>> select)
        {
			return await DbSet
				.Where(where)
				.Select(select)
				.ToListAsync();
		}

        public virtual async Task<bool> GetAnyAsync(Expression<Func<TEntity, bool>> where)
        {
			return await DbSet
				.AnyAsync(where);
        }
	}
}
