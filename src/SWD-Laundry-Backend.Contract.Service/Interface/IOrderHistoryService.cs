using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Enum;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface IOrderHistoryService :
    ICreateAble<OrderHistoryModel, string>,
    IGetAble<OrderHistory, string>,
    IUpdateAble<OrderHistoryModel, string>,
    IDeleteAble<string>
{
    Task<int> UpdateByLaundryStoreAsync(string id, LaundryStatus laundryStatus, CancellationToken cancellationToken = default);

    Task<ICollection<OrderHistory>> GetAllByCustomerAsync(string customerId, CancellationToken cancellationToken = default);
    Task<int> UpdateByStaffTripAsync(string orderId, DeliveryStatus deliveryStatus, CancellationToken cancellationToken = default);
}