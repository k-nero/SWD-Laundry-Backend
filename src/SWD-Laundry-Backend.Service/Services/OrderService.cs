using System.Linq.Expressions;
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;

//using StackExchange.Redis;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
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

    public OrderService(IOrderRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<string> CreateAsync(OrderModel model, CancellationToken cancellationToken = default)
    {
        var query = await _repository.AddAsync(_mapper.Map<Order>(model), cancellationToken);
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.DeleteAsync(x => x.Id == id, cancellationToken: cancellationToken);
        return numberOfRows;
    }

    public async Task<ICollection<Order>> GetAllAsync(OrderQuery? query, CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(cancellationToken: cancellationToken);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetSingleAsync(c => c.Id == id, cancellationToken, c => c.Customer
    , c => c.Staff
    , c => c.LaundryStore);
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
            .SetProperty(x => x.CustomerID, model.CustomerId)
            .SetProperty(x => x.StaffID, model.StaffId)
            .SetProperty(x => x.LaundryStoreID, model.LaundryStoreId)
            , cancellationToken);

        return numberOfRows;
    }


    public async Task<PaginatedList<Order>> GetPaginatedAsync(OrderQuery query, CancellationToken cancellationToken = default)
    {
        var list = await _repository
    .GetAsync(null 
    ,cancellationToken: cancellationToken
    ,c => c.Customer
    , c => c.Staff
    , c => c.LaundryStore);

        list = orderBy != null ?
            list.OrderBy(orderBy) :
            list.OrderBy(x => x.CreatedTime);
        var result = await list.PaginatedListAsync(query);
        return result;
    }
}