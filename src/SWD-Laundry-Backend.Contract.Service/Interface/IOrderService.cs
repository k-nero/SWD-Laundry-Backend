using System.Linq.Expressions;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface IOrderService :
    ICreateAble<OrderModel, string>,
    IGetAble<Order, string>,
    IUpdateAble<OrderModel, string>,
    IDeleteAble<string>
{
    Task<ICollection<Order>> GetAllByLaundryStoreAsync(string id, CancellationToken cancellationToken = default);

    Task<ICollection<Order>> GetAllByStaffTripAsync(DateTime startTime, DateTime endTime, CancellationToken cancellationToken = default);

    //Task<PaginatedList<Order>> GetByCustomerAsync(string customerId, short pg, short size, Expression<Func<Order, object>>? orderBy = null, CancellationToken cancellationToken = default);

    Task<int> UpdateByStaffTripAsync(string staffId, CancellationToken cancellationToken = default);
}