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

    public async Task<string> CreateAsync(BuildingModel model, CancellationToken cancellationToken = default)
    {
       var id = await _buildingRepository.AddAsync(_mapper.Map<Building>(model), cancellationToken);
        return id.Id;
    }

    public async Task<int> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
       int i = await _buildingRepository.DeleteAsync(x => x.Id == id, cancellationToken: cancellationToken);
        return i;
    }

    public async Task<ICollection<Building>> GetAllAsync(CancellationToken cancellationToken = default)
    {
       var buildings = await _buildingRepository.GetAsync(cancellationToken: cancellationToken);
       return await buildings.ToListAsync(cancellationToken);
    }

    public async Task<Building?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
       var building = await _buildingRepository.GetSingleAsync(x => x.Id == id, cancellationToken: cancellationToken);
        return building;
    }

    public async Task<int> UpdateAsync(string id, BuildingModel model, CancellationToken cancellationToken = default)
    {
        int i = await _buildingRepository.UpdateAsync(x => x.Id == id, 
            x => x.SetProperty(x => x.Name, y => model.Name ?? y.Name)
            .SetProperty(x => x.Address, y => model.Address ?? y.Address)
            .SetProperty(x => x.Description, y => model.Description ?? y.Description),
            cancellationToken: cancellationToken);
        return i;
    }
}
