using SWD_Laundry_Backend.Core.Models;

namespace SWD_Laundry_Backend.Core;

public class PaymentModel
{
    public double Price { get; set; }

    public OrderModel OrderModel { get; set; }
}