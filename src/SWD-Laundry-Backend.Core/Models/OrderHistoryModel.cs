using Microsoft.AspNetCore.Mvc.ModelBinding;
using SWD_Laundry_Backend.Core.Enum;

namespace SWD_Laundry_Backend.Core.Models;

public class OrderHistoryModel
{
    [BindNever]
    public string? OrderId { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }

    public OrderStatus OrderStatus { get; set; }
    public DeliveryStatus DeliveryStatus { get; set; }
    public LaundryStatus LaundryStatus { get; set; }
}