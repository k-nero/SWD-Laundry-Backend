using SWD_Laundry_Backend.Core.Enum;

namespace SWD_Laundry_Backend.Core.Models;

public class OrderModel
{
    public DateTime OrderDate { get; set; }
    public TimeFrame DeliveryTimeFrame { get; set; }
    public DateTime ExpectedFinishDate { get; set; }
    public string? Address { get; set; }
    public short Amount { get; set; }
    public double TotalPrice { get; set; }

    public string? CustomerName { get; set; }
    public string? StaffName { get; set; }
    public string?  LaundryStoreName { get; set; }

    public int OrderType { get; set; }
    public int PaymentType { get; set; }
}