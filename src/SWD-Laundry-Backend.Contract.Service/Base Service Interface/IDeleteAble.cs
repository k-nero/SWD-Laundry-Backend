using SWD_Laundry_Backend.Contract.Repository.Entity;

namespace SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
public interface IDeleteAble<in TKey> where TKey : BaseEntity
{
    Task DeleteAsync(TKey id, CancellationToken cancellationToken = default);
}
