using System.Linq.Expressions;
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Service.Services;

[ScopedDependency(ServiceType = typeof(IWalletService))]
public class WalletService : Base_Service.Service, IWalletService
{
    private readonly IWalletRepository _repository;
    private readonly IMapper _mapper;

    public WalletService(IWalletRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<string> CreateAsync(WalletModel model, CancellationToken cancellationToken = default)
    {
        var query = await _repository.AddAsync(_mapper.Map<Wallet>(model), cancellationToken);
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        int i = await _repository.DeleteAsync(x => x.Id == id, cancellationToken: cancellationToken);
        return i;
    }

    public async Task<ICollection<Wallet>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(cancellationToken: cancellationToken);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<Wallet?> GetByIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetSingleAsync(c => c.Id == userId, cancellationToken);
        return entity;
    }

    public async Task<PaginatedList<Wallet>> GetPaginatedAsync(short pg, short size, Expression<Func<Wallet, object>>? orderBy = null, CancellationToken cancellationToken = default)
    {
        var list = await _repository
.GetAsync(cancellationToken: cancellationToken);
        list = orderBy != null ?
            list.OrderBy(orderBy) :
            list.OrderBy(x => x.Balance);
        var result = await list.PaginatedListAsync(pg, size);
        return result;

    }

    public async Task<int> UpdateAsync(string id, WalletModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.Balance, model.Balance)
            , cancellationToken);

        return numberOfRows;
    }
}