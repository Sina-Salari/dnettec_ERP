using Dapper;
using Dnettec.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace Dnettec.Persistence.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IBaseEntity
	{
		protected internal Repository(DbContext databaseContext) : base()
		{
			DatabaseContext =
				databaseContext ??
				throw new ArgumentNullException(paramName: nameof(databaseContext));

			DbSet = DatabaseContext.Set<T>();
		}

		// **********
		protected DbSet<T> DbSet { get; }
		// **********

		// **********
		protected DbContext DatabaseContext { get; }
		// **********

		public virtual async Task InsertAsync(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(paramName: nameof(entity));
			}

			await DbSet.AddAsync(entity);
		}

		protected virtual void Update(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(paramName: nameof(entity));
			}

			DbSet.Update(entity);
		}

		public virtual async Task UpdateAsync(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(paramName: nameof(entity));
			}

			await Task.Run(() =>
			{
				DbSet.Update(entity);
			});
		}

		public virtual async Task DeleteAsync(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(paramName: nameof(entity));
			}

			await Task.Run(() =>
			{
				DbSet.Remove(entity);
			});
		}

		public virtual async Task<T> GetByIdAsync(System.Guid id)
		{
			return await DbSet.FindAsync(keyValues: id);
		}

		public virtual async Task<bool> DeleteByIdAsync(System.Guid id)
		{
			T entity =
				await GetByIdAsync(id);

			if (entity == null)
			{
				return false;
			}

			await DeleteAsync(entity);

			return true;
		}

		public virtual async Task<IList<T>> GetAllAsync()
		{
			// ToListAsync -> Extension Method -> using Microsoft.EntityFrameworkCore;
			var result =
				await
				DbSet.ToListAsync()
				;

			return result;
		}

		public virtual async Task<T> GetAsync(Expression<Func<T, bool>> where)
		{
			return await DbSet
				.Where(where)
				.FirstOrDefaultAsync();
		}

		public virtual async Task<TF> GetAsync<TF>(Expression<Func<T, bool>> where, Expression<Func<T, TF>> select)
		{
			return await DbSet
				.Where(where)
				.Select(select)
				.FirstOrDefaultAsync();
		}

		public virtual async Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> where)
		{
			return await DbSet
				.Where(where)
				.ToListAsync();
		}

		public virtual async Task<IList<TF>> GetManyAsync<TF>(Expression<Func<T, bool>> where, Expression<Func<T, TF>> select)
		{
			return await DbSet
				.Where(where)
				.Select(select)
				.ToListAsync();
		}

		public virtual async Task<bool> GetAnyAsync(Expression<Func<T, bool>> where)
		{
			return await DbSet
				.AnyAsync(where);
		}
	}
}
