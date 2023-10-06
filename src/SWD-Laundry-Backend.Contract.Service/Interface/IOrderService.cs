using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface IOrderService :
    ICreateAble<OrderModel, string>,
    IGetAble<Order, string>,
    IUpdateAble<OrderModel, string>,
    IDeleteAble<string>
{
    Task<ICollection<Order>> GetAllByLaundryStoreAsync(string id, CancellationToken cancellationToken = default);

    Task<ICollection<Order>> GetAllByStaffAsync(string id, CancellationToken cancellationToken = default);

    Task<ICollection<Order>> GetAllByCustomerAsync(string id, CancellationToken cancellationToken = default);
}