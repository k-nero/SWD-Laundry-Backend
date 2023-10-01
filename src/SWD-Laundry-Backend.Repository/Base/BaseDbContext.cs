using Microsoft.EntityFrameworkCore;

namespace SWD_Laundry_Backend.Repository.Base;
public abstract class BaseDbContext : DbContext
{
    protected BaseDbContext(DbContextOptions options) : base(options)
    {

    }
}
