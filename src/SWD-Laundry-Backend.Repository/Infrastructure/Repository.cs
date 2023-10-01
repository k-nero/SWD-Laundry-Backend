using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Contract.Repository.Base_Interface;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Infrastructure;
using SWD_Laundry_Backend.Repository.Base;

namespace SWD_Laundry_Backend.Repository.Infrastructure;
public class Repository<T> : BaseRepository<T>, IRepository<T>, IBaseRepository<T> where T : BaseEntity, new()
{
    public Repository(DbContext dbContext) : base(dbContext)
    {

    }
}
