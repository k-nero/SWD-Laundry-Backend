using System.Linq.Expressions;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.QueryObject;

namespace SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
public interface IGetAble<T, in TKey, Q> where T : class where Q : BaseQuery where TKey : notnull
{
    Task<ICollection<T>> GetAllAsync(Q query, CancellationToken cancellationToken = default);
    Task<PaginatedList<T>> GetPaginatedAsync(Q query, CancellationToken cancellationToken = default);

    Task<T?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
}
