using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;

namespace SWD_Laundry_Backend.Repository.Base;
public abstract class BaseDbContext : IdentityDbContext<ApplicationUser>
{
    protected BaseDbContext(DbContextOptions options) : base(options)
    {

    }
}
