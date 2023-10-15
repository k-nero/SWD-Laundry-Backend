using SWD_Laundry_Backend.Core.Models;
using SWD_Laundry_Backend.Core.ValueObject;

namespace SWD_Laundry_Backend.Contract.Service.Interface;
public interface IPaypalService
{
    Task<PaypalApiObjectModel.PaypalOrder.PaypalOrderResponse> CreatePaypalOrderAsync(TransactionModel model, CancellationToken cancellationToken = default);
    Task<object> CapturePaypalOrderAsync(string orderId, CancellationToken cancellationToken = default);
}
