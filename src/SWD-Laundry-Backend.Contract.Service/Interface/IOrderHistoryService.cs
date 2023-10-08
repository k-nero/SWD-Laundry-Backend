using System.Linq.Expressions;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Enum;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface IOrderHistoryService :
    ICreateAble<OrderHistoryModel, string>,
    IGetAble<OrderHistory, string>,
    IUpdateAble<OrderHistoryModel, string>,
    IDeleteAble<string>
{
    Task<int> UpdateByLaundryStoreAsync(string id, LaundryStatus laundryStatus, CancellationToken cancellationToken = default);

    Task<PaginatedList<OrderHistory>> GetByCustomerAsync(string customerId, short pg, short size, Expression<Func<OrderHistory, object>>? orderBy = null, CancellationToken cancellationToken = default);
    Task<PaginatedList<OrderHistory>> GetByLaundryStoreAsync(string laundryStoreId, short pg, short size, Expression<Func<OrderHistory, object>>? orderBy = null, CancellationToken cancellationToken = default);
    Task<int> UpdateByStaffTripAsync(string orderId, DeliveryStatus deliveryStatus, CancellationToken cancellationToken = default);
}