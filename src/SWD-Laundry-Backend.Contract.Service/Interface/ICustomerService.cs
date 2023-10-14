using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.QueryObject;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface ICustomerService :
    ICreateAble<CustomerModel, string>,
    IGetAble<Customer, string, CustomerQuery>,
    IUpdateAble<CustomerModel, string>,
    IDeleteAble<string>
{
}