using SWD_Laundry_Backend.Contract.Repository.Base_Interface;
using SWD_Laundry_Backend.Contract.Repository.Entity;

namespace SWD_Laundry_Backend.Contract.Repository.Infrastructure;
public interface ICacheLayer<T> : IBaseCacheLayer<T> where T : BaseEntity, new()
{

}
