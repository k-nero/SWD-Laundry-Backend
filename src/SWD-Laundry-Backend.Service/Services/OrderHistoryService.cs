using System.Linq.Expressions;
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
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
        var query = await _repository.AddAsync(_mapper.Map<OrderHistory>(model), cancellationToken);
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.DeleteAsync(x => x.Id == id, cancellationToken: cancellationToken);
        return numberOfRows;
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
        var entity = await _repository.GetSingleAsync(c => c.Id == id, cancellationToken);
        return entity;
    }

    public async Task<PaginatedList<OrderHistory>> GetPaginatedAsync(OrderHistoryQuery query, Expression<Func<OrderHistory, object>>? orderBy = null, CancellationToken cancellationToken = default)
    {
       
        var list = await _repository.GetAsync(null,
            cancellationToken: cancellationToken,
            c => c.Order, c => c.Order.LaundryStore);
        list = orderBy != null ?
            list.OrderBy(orderBy) :
            list.OrderBy(x => x.OrderStatus);
        if(query.LaundryStoreId != null)
        {
            list = list.Where(x => x.Order.LaundryStoreID == query.LaundryStoreId);
        }
        if(query.CustomerId != null)
        {
            list = list.Where(x => x.Order.CustomerID == query.CustomerId);
        }
        var result = await list.PaginatedListAsync(query.Page, query.Limit);
        return result;
    }

    public async Task<int> UpdateAsync(string id, OrderHistoryModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
            x => x
        .SetProperty(x => x.Message, model.Message)
        .SetProperty(x => x.Title, model.Title)
        .SetProperty(x => x.OrderStatus, model.OrderStatus)
        .SetProperty(x => x.DeliveryStatus, model.DeliveryStatus)
        .SetProperty(x => x.LaundryStatus, model.LaundryStatus), cancellationToken);
        return numberOfRows;
    }
}