using Invedia.DI.Attributes;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Interface;
using SWD_Laundry_Backend.Repository.Infrastructure;

namespace SWD_Laundry_Backend.Repository.Repository;

[ScopedDependency(ServiceType = typeof(IWalletRepository))]
public class WalletRepository : Repository<Wallet>, IWalletRepository
{
    public WalletRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}