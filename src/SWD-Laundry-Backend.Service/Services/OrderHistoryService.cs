using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;

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

    public async Task<ICollection<OrderHistory>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(cancellationToken: cancellationToken);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<OrderHistory?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var query = await _repository.GetAsync(c => c.Id == id, cancellationToken);
        var obj = await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        return obj;
    }

    public async Task<int> UpdateAsync(string id, OrderHistoryModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
    x => x
    .SetProperty(x => x.Message, model.Message)
    .SetProperty(x => x.Title, model.Title)
    .SetProperty(x => x.OrderStatus, model.OrderStatus)
    .SetProperty(x => x.DeliveryStatus, model.DeliveryStatus)
    .SetProperty(x => x.LaundryStatus, model.LaundryStatus)

    , cancellationToken);

        return numberOfRows;
    }
}