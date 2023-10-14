using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.QueryObject;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface IPaymentService :
    ICreateAble<PaymentModel, string>,
    IGetAble<Payment, string, PaymentQuery>,
    IUpdateAble<PaymentModel, string>,
    IDeleteAble<string>
{
}