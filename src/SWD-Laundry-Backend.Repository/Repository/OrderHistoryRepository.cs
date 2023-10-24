using Invedia.DI.Attributes;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Infrastructure;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Repository.Infrastructure;

namespace SWD_Laundry_Backend.Repository.Repository;

[ScopedDependency(ServiceType = typeof(IOrderHistoryRepository))]
public class OrderHistoryRepository : Repository<OrderHistory>, IOrderHistoryRepository
{
    public OrderHistoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}