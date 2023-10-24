using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invedia.DI.Attributes;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Infrastructure;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Repository.Infrastructure;

namespace SWD_Laundry_Backend.Repository.Repository;
[ScopedDependency(ServiceType = typeof(IStaffTripRepository))]
public class StaffTripRepository : Repository<Staff_Trip>, IStaffTripRepository
{
    public StaffTripRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
