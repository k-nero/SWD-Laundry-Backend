using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Core.Enum;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;
#nullable disable

public class OrderHistory : BaseEntity
{
    public string Title { get; set; }
    public string Message { get; set; }

    public OrderStatus OrderStatus { get; set; }
    public DeliveryStatus DeliveryStatus { get; set; }
    public LaundryStatus LaundryStatus { get; set; }

    ////===========================
    [ForeignKey("Order")]
    public string OrderID { get; set; }

    public Order Order { get; set; }
}