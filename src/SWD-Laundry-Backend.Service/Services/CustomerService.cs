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

[ScopedDependency(ServiceType = typeof(ICustomerService))]
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<string> CreateAsync(CustomerModel model, CancellationToken cancellationToken = default)
    {
        var query = await _repository.AddAsync(_mapper.Map<Customer>(model), cancellationToken);
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.DeleteAsync(x => x.Id == id, cancellationToken: cancellationToken);
        return numberOfRows;
    }

    public async Task<ICollection<Customer>> GetAllAsync(CustomerQuery? query, CancellationToken cancellationToken = default)
    {
        var list = await _repository
            .GetAsync(null, cancellationToken: cancellationToken,
            c => c.ApplicationUser);

        return await list.ToListAsync(cancellationToken);
    }

    public async Task<Customer?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {

        var customer = await _repository.GetSingleAsync(c => c.Id == id, cancellationToken, x => x.ApplicationUser);
        return customer;
    }

    public async Task<PaginatedList<Customer>> GetPaginatedAsync(CustomerQuery query, Expression<Func<Customer, object>>? orderBy = null, CancellationToken cancellationToken = default)
    {
        var list = await _repository.GetAsync(cancellationToken: cancellationToken);
        list = orderBy != null ? 
            list.OrderBy(orderBy) :
            list.OrderBy(x => x.ApplicationUserID);
        var result = await list.PaginatedListAsync(query.Page, query.Limit);
        return result;

    }

    public async Task<int> UpdateAsync(string id, CustomerModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await _repository.UpdateAsync(x => x.Id == id,
         x => x
        .SetProperty(x => x.BuildingID, model.BuildingId)
        .SetProperty(x => x.ApplicationUserID, model.ApplicationUserId)
        , cancellationToken);

        return numberOfRows;
    }


}