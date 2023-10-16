using SWD_Laundry_Backend.Core.Enum;

namespace SWD_Laundry_Backend.Core.Models;

public class OrderModel
{
    public string? CustomerId { get; set; }
    public string? StaffId { get; set; }
    public string? LaundryStoreId { get; set; }

    public DateTime OrderDate { get; set; }
    public TimeFrame DeliveryTimeFrame { get; set; }
    public DateTime ExpectedFinishDate { get; set; }

    //public OrderType OrderType { get; set; }
    public PaymentType PaymentType { get; set; }

    public short Amount { get; set; }
    public double TotalPrice { get; set; }
    public string? Address { get; set; }
}