using AutoMapper;
using Invedia.DI.Attributes;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Service.Services;

//[ScopedDependency(ServiceType = typeof(ITransactionService))]
public class TransactionService : Base_Service.Service, ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly AutoMapper.Mapper _mapper;

    public TransactionService(ITransactionRepository repository, AutoMapper.Mapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<string> CreateAsync(TransactionModel model, CancellationToken cancellationToken = default)
    {
        var query = await _repository.AddAsync(_mapper.Map<Transaction>(model), cancellationToken);
        var objectId = query.Id;
        return objectId;
    }

    public Task<ICollection<Transaction>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Transaction?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(string id, TransactionModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}