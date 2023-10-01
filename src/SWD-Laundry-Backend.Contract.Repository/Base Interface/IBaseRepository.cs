using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace SWD_Laundry_Backend.Contract.Repository.Base_Interface;
public interface IBaseRepository<T> where T : Entity.BaseEntity, new()
{
    Task<T?> GetSingleAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includes);
    Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includes);
    Task<int> UpdateAsync(Expression<Func<T, bool>> filter, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> update, CancellationToken cancellationToken = default);
    Task<int> DeleteAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
}
