using System.Linq.Expressions;
using SWD_Laundry_Backend.Contract.Repository.Base_Interface;
using SWD_Laundry_Backend.Contract.Repository.Entity;

namespace SWD_Laundry_Backend.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {


        public int Add(T entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includes)
        {
            throw new NotImplementedException();
        }

        public int Update(Expression<Func<T, bool>> filter, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
