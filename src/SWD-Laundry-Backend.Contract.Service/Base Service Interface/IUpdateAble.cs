namespace SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
public interface IUpdateAble<in T, in Tkey> where T : class, new()
{ 
    Task UpdateAsync(Tkey id, T model, CancellationToken cancellationToken = default);
}
