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
public class BuildingService : Base_Service.Service, IBuidingService
{

    private readonly IBuildingRepository _buildingRepository;
    private readonly IMapper _mapper;
    private readonly ICacheLayer<Building> _cacheLayer;

    public BuildingService(IBuildingRepository buildingRepository, IMapper mapper, ICacheLayer<Building> cacheLayer)
    {
        _buildingRepository = buildingRepository;
        _mapper = mapper;
        _cacheLayer = cacheLayer;
    }

    public async Task<string> CreateAsync(BuildingModel model, CancellationToken cancellationToken = default)
    {
        await _cacheLayer.RemoveMultipleAsync(typeof(Building).Name, cancellationToken);
        var id = await _buildingRepository.AddAsync(_mapper.Map<Building>(model), cancellationToken);
        return id.Id;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        int i = await _buildingRepository.DeleteAsync(x => x.Id == id, cancellationToken);
        await _cacheLayer.RemoveMultipleAsync(typeof(Building).Name, cancellationToken);
        return i;
    }

    public async Task<ICollection<Building>> GetAllAsync(BuildingQuery? query, CancellationToken cancellationToken = default)
    {
        var buildings = await _buildingRepository.GetAsync(cancellationToken: cancellationToken);
        return await buildings.ToListAsync(cancellationToken);
    }

    public async Task<Building?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var buildingCached = await _cacheLayer.GetSingleAsync(id, cancellationToken);
        if(buildingCached != null)
        {
            return buildingCached;
        }
        var building = await _buildingRepository.GetSingleAsync(x => x.Id == id, cancellationToken: cancellationToken);
        if(building != null)
        {
            await _cacheLayer.AddSingleAsync(building, cancellationToken);
        }
        return building;
    }

    public async Task<PaginatedList<Building>> GetPaginatedAsync(BuildingQuery query, CancellationToken cancellationToken = default)
    {
        string key = "";

        key = CoreHelper.ObjecToQueryString(query);

        var buildingCached = await _cacheLayer.GetMultipleAsync(key, cancellationToken);
        if (buildingCached != null)
        {
            await _cacheLayer.RefreshKeyAsync(key, cancellationToken);
            return buildingCached;
        }
        var buildings = await _buildingRepository
            .GetAsync(c => c.IsDelete == query.IsDeleted
            , cancellationToken: cancellationToken);
        var result = await buildings.PaginatedListAsync(query);
        await _cacheLayer.AddMultipleAsync(key, result, cancellationToken);
        return result;
    }

    public async Task<int> UpdateAsync(string id, BuildingModel model, CancellationToken cancellationToken = default)
    {
        int i = await _buildingRepository.UpdateAsync(x => x.Id == id,
            x => x
            .SetProperty(x => x.Name, y => model.Name ?? y.Name)
            .SetProperty(x => x.Address, y => model.Address ?? y.Address)
            .SetProperty(x => x.Description, y => model.Description ?? y.Description),
            cancellationToken: cancellationToken);
        await _cacheLayer.RemoveMultipleAsync(typeof(Building).Name, cancellationToken);
        return i;
    }
}
