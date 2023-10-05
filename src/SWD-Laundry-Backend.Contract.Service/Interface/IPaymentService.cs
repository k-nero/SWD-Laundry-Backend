using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Service.Base_Service_Interface;
using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Contract.Service.Interface;

public interface IPaymentService :
    ICreateAble<PaymentModel, string>,
    IGetAble<Payment, string>,
    IUpdateAble<PaymentModel, string>,
    IDeleteAble<string>
{
}