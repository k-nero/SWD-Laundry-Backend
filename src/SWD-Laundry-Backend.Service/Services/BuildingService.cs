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

[ScopedDependency(ServiceType = typeof(IBuidingService))]
public class BuildingService(IBuildingRepository buildingRepository, IMapper mapper, ICacheLayer<Building> cacheLayer) : Base_Service.Service, IBuidingService
{
    public async Task<string> CreateAsync(BuildingModel model, CancellationToken cancellationToken = default)
    {
        var id = await buildingRepository.AddAsync(mapper.Map<Building>(model), cancellationToken);
        await cacheLayer.RemoveMultipleAsync([typeof(Building).Name], cancellationToken);
        return id.Id;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        int i = await buildingRepository.DeleteAsync(x => x.Id == id, cancellationToken);
        await cacheLayer.RemoveMultipleAsync([typeof(Building).Name, id], cancellationToken);
        return i;
    }

    public async Task<ICollection<Building>> GetAllAsync(BuildingQuery? query, CancellationToken cancellationToken = default)
    {
        var buildings = await buildingRepository.GetAsync(cancellationToken: cancellationToken);
        return await buildings.ToListAsync(cancellationToken);
    }

    public async Task<Building?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var buildingCached = await cacheLayer.GetSingleAsync(id, cancellationToken);
        if(buildingCached != null)
        {
            return buildingCached;
        }
        var building = await buildingRepository.GetSingleAsync(x => x.Id == id, cancellationToken: cancellationToken);
        if(building != null)
        {
            await cacheLayer.AddSingleAsync(building, cancellationToken);
        }
        return building;
    }

    public async Task<PaginatedList<Building>> GetPaginatedAsync(BuildingQuery query, CancellationToken cancellationToken = default)
    {
        string key = "";

        key = CoreHelper.ObjecToQueryString(query);

        var buildingCached = await cacheLayer.GetMultipleAsync(key, cancellationToken);
        if (buildingCached != null)
        {
            await cacheLayer.RefreshKeyAsync(key, cancellationToken);
            return buildingCached;
        }
        var buildings = await buildingRepository
            .GetAsync(c => c.IsDelete == query.IsDeleted
            , cancellationToken: cancellationToken);
        var result = await buildings.PaginatedListAsync(query);
        await cacheLayer.AddMultipleAsync(key, result, cancellationToken);
        return result;
    }

    public async Task<int> UpdateAsync(string id, BuildingModel model, CancellationToken cancellationToken = default)
    {
        int i = await buildingRepository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.Name, y => model.Name ?? y.Name)
            .SetProperty(x => x.Address, y => model.Address ?? y.Address)
            .SetProperty(x => x.Description, y => model.Description ?? y.Description),
            cancellationToken: cancellationToken);
        await cacheLayer.RemoveMultipleAsync(new string[] { typeof(Building).Name, id}, cancellationToken);
        return i;
    }
}
