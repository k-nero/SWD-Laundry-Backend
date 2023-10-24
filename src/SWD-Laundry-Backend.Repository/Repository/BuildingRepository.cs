using Invedia.DI.Attributes;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Repository.Infrastructure;

namespace SWD_Laundry_Backend.Repository.Repository;

[ScopedDependency(ServiceType = typeof(IBuildingRepository))]
public class BuildingRepository : Repository<Building>, IBuildingRepository
{
    public BuildingRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}
