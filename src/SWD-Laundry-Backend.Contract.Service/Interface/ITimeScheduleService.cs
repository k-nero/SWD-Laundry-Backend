using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.QueryObject;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface ITimeScheduleService : 
    ICreateAble<TimeScheduleModel, string>, 
    IGetAble<TimeSchedule, string, TimeScheduleQuery>, 
    IUpdateAble<TimeScheduleModel, string>, 
    IDeleteAble<string>
{
}