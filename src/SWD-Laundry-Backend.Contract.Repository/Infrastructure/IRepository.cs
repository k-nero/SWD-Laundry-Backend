using SWD_Laundry_Backend.Contract.Repository.Base_Interface;

namespace SWD_Laundry_Backend.Contract.Repository.Infrastructure;
public interface IRepository<T> : IBaseRepository<T> where T : Entity.BaseEntity, new()
{

}
