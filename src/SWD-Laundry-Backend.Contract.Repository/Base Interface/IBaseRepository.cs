using System.Linq.Expressions;

namespace SWD_Laundry_Backend.Contract.Repository.Base_Interface;
public interface IBaseRepository<T> where T : Entity.BaseEntity, new()
{
    T GetSingle(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includes);
    IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includes);
    int Update(Expression<Func<T, bool>> filter, T entity);
    int Delete(Expression<Func<T, bool>> filter);
    int Add(T entity);
}
