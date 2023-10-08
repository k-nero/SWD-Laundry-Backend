using System.Linq.Expressions;
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;

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

    public async Task<ICollection<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(cancellationToken: cancellationToken);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<ICollection<Order>> GetAllByLaundryStoreAsync(string id, CancellationToken cancellationToken = default)
    {
        var list = await _repository
            .GetAsync(c => c.LaundryStoreID == id,
            cancellationToken: cancellationToken);

        return await list.ToListAsync(cancellationToken);
    }

    public async Task<ICollection<Order>> GetAllByStaffTripAsync(DateTime startTime, DateTime endTime, CancellationToken cancellationToken = default)
    {
        var list = await _repository
       .GetAsync(c => c.OrderDate >= startTime &&
       c.OrderDate <= endTime,
       cancellationToken: cancellationToken);

        return await list.ToListAsync(cancellationToken);
    }

    public async Task<ICollection<Order>> GetAllByCustomerAsync(string id, CancellationToken cancellationToken = default)
    {
        var list = await _repository
            .GetAsync(c => c.CustomerID == id,
            cancellationToken: cancellationToken);

        return await list.ToListAsync(cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var query = await _repository.GetAsync(c => c.Id == id, cancellationToken);
        var obj = await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        return obj;
    }

    public async Task<int> UpdateAsync(string id, OrderModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.OrderDate, model.OrderDate)
            .SetProperty(x => x.DeliveryTimeFrame, model.DeliveryTimeFrame)
            .SetProperty(x => x.ExpectedFinishDate, model.ExpectedFinishDate)
            .SetProperty(x => x.OrderType, model.OrderType)
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

    public async Task<int> UpdateByStaffTripAsync(string staffId, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.StaffID == staffId,
            x => x
            .SetProperty(x => x.StaffID, staffId),
            cancellationToken);

        return numberOfRows;
    }

    public Task<PaginatedList<Order>> GetPaginatedAsync(short pg, short size, Expression<Func<Order, object>>? orderBy = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}