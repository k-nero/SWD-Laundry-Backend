using Invedia.DI.Attributes;

using SWD_Laundry_Backend.Contract.Repository.Entity;

using SWD_Laundry_Backend.Contract.Repository.Infrastructure;

using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Repository.Infrastructure;

namespace SWD_Laundry_Backend.Repository.Repository;

[ScopedDependency(ServiceType = typeof(ITimeScheduleRepository))]
public class TimeScheduleRepository : Repository<TimeSchedule>, ITimeScheduleRepository
{
    public TimeScheduleRepository(AppDbContext dbContext, ICacheLayer<TimeSchedule> cacheLayer) : base(dbContext, cacheLayer)
    {
    }
}