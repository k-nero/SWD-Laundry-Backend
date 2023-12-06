using System.Linq.Expressions;
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;
using SWD_Laundry_Backend.Contract.Repository.Infrastructure;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.QueryObject;
using SWD_Laundry_Backend.Core.Utils;

namespace SWD_Laundry_Backend.Service.Services;

[ScopedDependency(ServiceType = typeof(ILaundryStoreService))]
public class LaundryStoreService(ILaundryStoreRepository repository, IMapper mapper, IIdentityService identityService, ICacheLayer<LaundryStore> cacheLayer) : Base_Service.Service, ILaundryStoreService
{
    public async Task<string> CreateAsync(LaundryStoreModel model, CancellationToken cancellationToken = default)
    {
        var query = await repository.AddAsync(mapper.Map<LaundryStore>(model), cancellationToken);
        var user = await  identityService.GetUserByIdAsync(query.ApplicationUserID);
        await identityService.AddToRoleAsync(user, "LaundryStore");
        var objectId = query.Id;
        return objectId;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        int i = await repository.DeleteAsync(x => x.Id == id,
            cancellationToken);
        return i;
    }

    public async Task<ICollection<LaundryStore>> GetAllAsync(LaundryStoreQuery? query, CancellationToken cancellationToken = default)
    {
       var list = await repository.GetAsync(null,cancellationToken: cancellationToken, c => c.ApplicationUser);
       var test = await list.ToListAsync(cancellationToken: cancellationToken);
        return await list.ToListAsync(cancellationToken);
    }

    public async Task<LaundryStore?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var customer = await repository.GetSingleAsync(c => c.Id == id, cancellationToken, x => x.ApplicationUser);
        return customer;
    }

    public async Task<PaginatedList<LaundryStore>> GetPaginatedAsync(LaundryStoreQuery query, CancellationToken cancellationToken = default)
    {
        var list = await repository.GetAsync(
            c => c.IsDelete == query.IsDeleted
            , cancellationToken: cancellationToken
            , c => c.ApplicationUser
            , c => c.ApplicationUser.Wallet);
        if(query.UserId != null)
        {
            list = list.Where(c => c.ApplicationUserID == query.UserId);
        }
        var result = await list.PaginatedListAsync(query);
        return result;
    }

    public async Task<int> UpdateAsync(string id, LaundryStoreModel model, CancellationToken cancellationToken = default)
    {
        var numberOfRows = await repository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.Name, model.Name)
            .SetProperty(x => x.StartTime, model.StartTime)
            .SetProperty(x => x.EndTime, model.EndTime)
            .SetProperty(x => x.Address, model.Address)
            .SetProperty(x => x.Status, model.Status)
            , cancellationToken);

        return numberOfRows;
    }
}