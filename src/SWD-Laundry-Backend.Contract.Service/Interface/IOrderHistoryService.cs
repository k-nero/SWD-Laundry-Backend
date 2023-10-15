using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.Models.Common;
using SWD_Laundry_Backend.Core.QueryObject;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface IOrderHistoryService :
    ICreateAble<OrderHistoryModel, string>,
    IGetAble<OrderHistory, string, OrderHistoryQuery>,
    IUpdateAble<OrderHistoryModel, string>,
    IDeleteAble<string>
{
}