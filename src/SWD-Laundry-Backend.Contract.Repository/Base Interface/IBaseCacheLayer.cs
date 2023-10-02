namespace SWD_Laundry_Backend.Contract.Repository.Base_Interface;
public interface IBaseCacheLayer<T> where T : Entity.BaseEntity, new()
{
    Task<T?> GetSingleAsync(string key, CancellationToken cancellationToken = default);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
}
