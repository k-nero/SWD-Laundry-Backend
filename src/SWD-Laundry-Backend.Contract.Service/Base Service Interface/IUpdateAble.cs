using SWD_Laundry_Backend.Contract.Repository.Entity;

namespace SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
public interface IUpdateAble<in T, in Tkey> where T : BaseEntity, new()
{ 
    Task UpdateAsync(Tkey id, T model, CancellationToken cancellationToken = default);
}
