using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface IStaffService :
    ICreateAble<StaffModel, string>,
    IGetAble<Staff, string>,
    IUpdateAble<StaffModel, string>,
    IDeleteAble<string>
{
}