using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Contract.Service.Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Service.Services;
[ScopedDependency(ServiceType = typeof(IBuidingService))]
public class BuildingService : Base_Service.Service, IBuidingService
{

    private readonly IBuildingRepository _buildingRepository;
    private readonly IMapper _mapper;

    public BuildingService (IBuildingRepository buildingRepository, IMapper mapper)
    {
        _buildingRepository = buildingRepository;
        _mapper = mapper;
    }

    public Task<string> CreateAsync(BuildingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Building>> GetAllAsync(CancellationToken cancellationToken = default)
    {
       var buildings = await _buildingRepository.GetAsync(cancellationToken: cancellationToken);
       return await buildings.ToListAsync(cancellationToken: cancellationToken);
    }

    public Task<Building> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string id, BuildingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
