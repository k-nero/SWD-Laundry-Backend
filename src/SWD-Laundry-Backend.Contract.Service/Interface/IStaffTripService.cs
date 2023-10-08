using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface IStaffTripService : 
    ICreateAble<StaffTripModel, string>, 
    IGetAble<Staff_Trip, string>, 
    IUpdateAble<StaffTripModel, string>, 
    IDeleteAble<string>
{
    Task<int> UpdateCollectAsync(string id, double tripCollect, CancellationToken cancellationToken = default);
}