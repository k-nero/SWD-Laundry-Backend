using System.Linq.Expressions;
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
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

[ScopedDependency(ServiceType = typeof(ITransactionService))]
public class TransactionService : Base_Service.Service, ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICacheLayer<Transaction> _cacheLayer;

    public TransactionService(ITransactionRepository repository, IMapper mapper, ICacheLayer<Transaction> cacheLayer)
    {
        _repository = repository;
        _mapper = mapper;
        _cacheLayer = cacheLayer;
    }

    public Task<int> CancelTransactionAsync(CancellationToken cancellationToken = default)
    {
       var i = _repository.UpdateAsync(x => x.Status == TransactionStatus.Pending && (DateTimeOffset.Now - x.CreatedTime) >= TimeSpan.FromDays(30),
           x => x.SetProperty(x => x.Status, TransactionStatus.Failed), cancellationToken);
       return i;
    }

    public async Task<string> CreateAsync(TransactionModel model, CancellationToken cancellationToken = default)
    {
        var query = await _repository.AddAsync(_mapper.Map<Transaction>(model), cancellationToken);
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        int i = await _repository.DeleteAsync(x => x.Id == id,
            cancellationToken);
        return i;
    }

    public async Task<ICollection<Transaction>> GetAllAsync(TransactionQuery? query, CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(cancellationToken: cancellationToken);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<Transaction?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetSingleAsync(c => c.Id == id, cancellationToken);
        return entity;
    }


    public async Task<PaginatedList<Transaction>> GetPaginatedAsync(TransactionQuery query, CancellationToken cancellationToken = default)
    {
        var list = await _repository
        .GetAsync(c => c.IsDelete == query.IsDeleted
        , cancellationToken: cancellationToken);


        var result = await list.PaginatedListAsync(query);
        return result;
    }

    public async Task<int> UpdateAsync(string id, TransactionModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.Status, model.Status)
            .SetProperty(x => x.Amount, model.Amount)
            .SetProperty(x => x.TransactionType, model.TransactionType)
            .SetProperty(x => x.PaymentType, model.PaymentType)
            .SetProperty(x => x.Description, model.Description)
            , cancellationToken);

        return numberOfRows;
    }
}
