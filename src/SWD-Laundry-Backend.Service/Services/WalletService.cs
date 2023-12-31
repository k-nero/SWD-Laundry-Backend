﻿using System.Linq.Expressions;
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Infrastructure;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.QueryObject;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Service.Services;

[ScopedDependency(ServiceType = typeof(IWalletService))]
public class WalletService : Base_Service.Service, IWalletService
{
    private readonly IWalletRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICacheLayer<Wallet> _cacheLayer;

    public WalletService(IWalletRepository repository, IMapper mapper, ICacheLayer<Wallet> cacheLayer)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheLayer = cacheLayer;
    }

    public async Task<string> CreateAsync(WalletModel model, CancellationToken cancellationToken = default)
    {
        var query = await _repository.AddAsync(_mapper.Map<Wallet>(model), cancellationToken);
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        int i = await _repository.DeleteAsync(x => x.Id == id,
            cancellationToken);
        return i;
    }

    public async Task<ICollection<Wallet>> GetAllAsync(WalletQuery? query, CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(cancellationToken: cancellationToken);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<Wallet?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetSingleAsync(c => c.Id == id, cancellationToken);
        return entity;
    }

    public async Task<PaginatedList<Wallet>> GetPaginatedAsync(WalletQuery query, CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(c => c.IsDelete == query.IsDeleted, cancellationToken: cancellationToken);
        var result = await list.PaginatedListAsync(query) ;
        return result;

    }

    public async Task<int> UpdateAsync(string id, WalletModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.Balance, model.Balance),
            cancellationToken);

        return numberOfRows;
    }
}