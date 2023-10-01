using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SWD_Laundry_Backend.Contract.Repository.Base_Interface;
using SWD_Laundry_Backend.Contract.Repository.Entity;

namespace SWD_Laundry_Backend.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected readonly DbContext _dbContext;

        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get
            {
                if (_dbSet != null)
                {
                    return _dbSet;
                }

                _dbSet = _dbContext.Set<T>();
                return _dbSet;
            }
        }

        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var e = await DbSet.AddAsync(entity);
            return e.Entity;
        }

        public virtual async Task<int> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            var i = await DbSet.Where(filter).ExecuteDeleteAsync();
            return i;
        }

        public virtual async Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includes)
        {

            return await Task.Run(() =>
            {
                var query = DbSet.AsNoTracking().Where(filter);
                if (includes != null)
                {
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                }
                return query;
            }); ;
        }

        public virtual async Task<T?> GetSingleAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includes)
        {
            var query = DbSet.Where(filter).AsNoTracking();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<int> UpdateAsync(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> update)
        {
            int i = await DbSet.Where(filter).ExecuteUpdateAsync(update);
            return i;
        }
    }
}
