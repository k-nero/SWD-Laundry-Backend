using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace SWD_Laundry_Backend.Contract.Repository.Base_Interface;
public interface IBaseRepository<T> where T : Entity.BaseEntity, new()
{
    Task<T?> GetSingleAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includes);
    Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[]? includes);
    Task<int> UpdateAsync(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> update);
    Task<int> DeleteAsync(Expression<Func<T, bool>> filter);
    Task<T> AddAsync(T entity);
}
