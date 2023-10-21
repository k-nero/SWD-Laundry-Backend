using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Enum;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.QueryObject;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Service.Services;

[ScopedDependency(ServiceType = typeof(IOrderHistoryService))]
public class OrderHistoryService : IOrderHistoryService
{
    private readonly IOrderHistoryRepository _repository;
    private readonly IMapper _mapper;

    public OrderHistoryService(IOrderHistoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<string> CreateAsync(OrderHistoryModel model, CancellationToken cancellationToken = default)
    {
        model.OrderStatus = OrderStatus.Processing;
        if (model.DeliveryStatus == DeliveryStatus.DeliveringLaundry)
        {
            model.Title = "Order received";
            model.Message = "Shipper have collected order, on the wait to delivery.";
        }

        if (model.DeliveryStatus == DeliveryStatus.ReachedLaundry)
        {
            model.Title = "Order reaching laundry store";
            model.Message = "Order have been taking by laundry store, waiting for processing";
            model.LaundryStatus = LaundryStatus.Washing;
        }

        if (model.LaundryStatus == LaundryStatus.Finished)
        {
            model.Title = "Laundry store finished order";
            model.Message = "Order have been finished by laundry store, waiting for shipper";
            model.DeliveryStatus = DeliveryStatus.Pending;
        }

        if (model.DeliveryStatus == DeliveryStatus.DeliveringCustomer)
        {
            model.LaundryStatus = LaundryStatus.Finished;
            model.Title = "Order received";
            model.Message = "Shipper have collected order, on the wait to delivery.";
        }

        if (model.DeliveryStatus == DeliveryStatus.ReachedCustomer)
        {
            model.LaundryStatus = LaundryStatus.Finished;
            model.Title = "Order reaching customer's building";
            model.Message = "Shipper has come, waiting for customer.";
        }
        if (model.DeliveryStatus == DeliveryStatus.Delivered)
        {
            model.LaundryStatus = LaundryStatus.Finished;
            model.DeliveryStatus = DeliveryStatus.ReachedCustomer;
            model.Title = "Order finished";
            model.Message = "Customer have received order.";
            model.OrderStatus = OrderStatus.Completed;
        }

        var query = await _repository.AddAsync(_mapper.Map<OrderHistory>(model), cancellationToken);
        return query.Id;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        int i = await _repository.UpdateAsync(x => x.Id == id,
    x => x
    .SetProperty(x => x.IsDelete, true),
    cancellationToken: cancellationToken);
        return i;
    }

    public async Task<ICollection<OrderHistory>> GetAllAsync(OrderHistoryQuery query, CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(cancellationToken: cancellationToken);
        if (query.LaundryStoreId != null)
        {
            list.Include(x => x.Order).ThenInclude(x => x.LaundryStore);
            list = list.Where(x => x.Order.LaundryStoreID == query.LaundryStoreId);
        }
        if (query.CustomerId != null)
        {
            list.Include(x => x.Order).ThenInclude(x => x.Customer);
            list = list.Where(x => x.Order.CustomerID == query.CustomerId);
        }
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<OrderHistory?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetSingleAsync(c => c.Id == id, cancellationToken, c => c.Order);
        return entity;
    }

    public async Task<PaginatedList<OrderHistory>> GetPaginatedAsync(OrderHistoryQuery query, CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(
            c => c.IsDelete == query.IsDeleted,
        cancellationToken: cancellationToken,
    c => c.Order, c => c.Order.LaundryStore);
        if (query.OrderId != null)
        {
            list = list.Where(x => x.OrderID == query.OrderId);
        }
        if (query.LaundryStoreId != null)
        {
            list = list.Where(x => x.Order.LaundryStoreID == query.LaundryStoreId);
        }
        if (query.CustomerId != null)
        {
            list = list.Where(x => x.Order.CustomerID == query.CustomerId);
        }
        var result = await list.PaginatedListAsync(query);
        return result;
    }

    public async Task<int> UpdateAsync(string id, OrderHistoryModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
            x => x
        .SetProperty(x => x.OrderStatus, model.OrderStatus)
        .SetProperty(x => x.DeliveryStatus, model.DeliveryStatus)
        .SetProperty(x => x.LaundryStatus, model.LaundryStatus), cancellationToken);
        return numberOfRows;
    }
}