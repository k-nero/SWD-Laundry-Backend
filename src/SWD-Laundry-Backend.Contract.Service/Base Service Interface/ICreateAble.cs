using SWD_Laundry_Backend.Contract.Repository.Entity;

namespace SWD_Laundry_Backend.Contract.Service.Base_Service_Interface
{
    public interface ICreateAble<in T, TKey> where T : BaseEntity, new()
    {
        Task<TKey> CreateAsync(T model, CancellationToken cancellationToken = default);
    }
}
