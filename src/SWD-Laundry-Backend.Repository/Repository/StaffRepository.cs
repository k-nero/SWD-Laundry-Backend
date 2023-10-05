using Invedia.DI.Attributes;
using SWD_Laundry_Backend.Contract.Repository.Infrastructure;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Repository.Infrastructure;

namespace SWD_Laundry_Backend.Repository.Repository;

[ScopedDependency(ServiceType = typeof(IStaffRepository))]
public class StaffRepository : Repository<Staff>, IStaffRepository
{
    public StaffRepository(AppDbContext dbContext, ICacheLayer<Staff> cacheLayer) : base(dbContext, cacheLayer)
    {
    }
}