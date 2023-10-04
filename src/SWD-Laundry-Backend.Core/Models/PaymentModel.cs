namespace SWD_Laundry_Backend.Core.Models;

public class PaymentModel
{
    public double Price { get; set; }

    public OrderModel OrderModel { get; set; }
}