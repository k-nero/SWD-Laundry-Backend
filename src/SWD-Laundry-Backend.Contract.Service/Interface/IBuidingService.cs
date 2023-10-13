using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.QueryObject;

namespace SWD_Laundry_Backend.Contract.Service.Interface;
public interface IBuidingService :
    ICreateAble<BuildingModel, string>,
    IGetAble<Building, string, BuildingQuery>, 
    IUpdateAble<BuildingModel, string>, 
    IDeleteAble<string>
{
}
