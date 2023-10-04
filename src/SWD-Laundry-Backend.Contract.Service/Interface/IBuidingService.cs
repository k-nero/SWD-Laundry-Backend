using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Contract.Service.Interface;
public interface IBuidingService : ICreateAble<BuildingModel, string>, IGetAble<Building, string>, IUpdateAble<BuildingModel, string>, IDeleteAble<string>
{

}
