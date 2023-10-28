using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;

//using StackExchange.Redis;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Infrastructure;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Enum;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.QueryObject;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Service.Services;

[ScopedDependency(ServiceType = typeof(IOrderService))]
public class OrderService : IOrderService
{
    private readonly IOrderRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICacheLayer<Order> _cacheLayer;
    private readonly IOrderHistoryRepository _orderHistoryRepository;

    public OrderService(IOrderRepository repository, IMapper mapper, ICacheLayer<Order> cacheLayer, IOrderHistoryRepository orderHistoryRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheLayer = cacheLayer;
        _orderHistoryRepository = orderHistoryRepository;
    }

    public async Task<string> CreateAsync(OrderModel model, CancellationToken cancellationToken = default)
    {
        model.StaffId = null;
        var query = await _repository.AddAsync(_mapper.Map<Order>(model), cancellationToken);
        if(query != null)
        {
            OrderHistoryModel historyModel = new()
            {
                OrderId = query.Id,
                Title = "Delivery Preparing",
                Message = "Order created and shipper will collect your order soon.",
                OrderStatus = OrderStatus.Preparing,
                DeliveryStatus = DeliveryStatus.Pending,
                LaundryStatus = LaundryStatus.Pending,
            };

            await _orderHistoryRepository.AddAsync(_mapper.Map<OrderHistory>(historyModel), cancellationToken);
        }
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        int i = await _repository.DeleteAsync(x => x.Id == id,
            cancellationToken);
        return i;
    }

    public async Task<ICollection<Order>> GetAllAsync(OrderQuery? query, CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(cancellationToken: cancellationToken);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetSingleAsync(c => c.Id == id, cancellationToken, c => c.Customer,
            c => c.Staff,
            c => c.LaundryStore);
        return entity;
    }

    public async Task<int> UpdateAsync(string id, OrderModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.OrderDate, model.OrderDate)
            .SetProperty(x => x.DeliveryTimeFrame, model.DeliveryTimeFrame)
            .SetProperty(x => x.ExpectedFinishDate, model.ExpectedFinishDate)

            .SetProperty(x => x.PaymentType, model.PaymentType)
            .SetProperty(x => x.Address, model.Address)
            .SetProperty(x => x.Amount, model.Amount)
            .SetProperty(x => x.TotalPrice, model.TotalPrice)
            .SetProperty(x => x.CustomerID, y => model.CustomerId ?? y.CustomerID)
            .SetProperty(x => x.StaffID, y => model.StaffId ?? y.StaffID)
            .SetProperty(x => x.LaundryStoreID, y => model.LaundryStoreId ?? y.LaundryStoreID),
            cancellationToken);

        return numberOfRows;
    }

    public async Task<PaginatedList<Order>> GetPaginatedAsync(OrderQuery query, CancellationToken cancellationToken = default)
    {
        var list = await _repository
        .GetAsync(
        c => c.IsDelete == query.IsDeleted,
        cancellationToken: cancellationToken,
        c => c.Customer,
        c => c.Staff,
        c => c.LaundryStore);
        if (query.LaundryStoreId != null)
        {
            list = list.Where(x => x.LaundryStoreID == query.LaundryStoreId);
        }
        if (query.CustomerId != null)
        {
            list = list.Where(x => x.CustomerID == query.CustomerId);
        }

        var result = await list.PaginatedListAsync(query);
        return result;
    }
}