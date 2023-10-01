using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Enum;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;
#nullable disable

public class OrderHistory : BaseEntity
{
    public string Title { get; set; }
    public string Message { get; set; }

    #region Relationship

    [ForeignKey("Order")]
    public string OrderID { get; set; }

    public Order Order { get; set; }

    #endregion Relationship

    #region Special attributes

    public OrderStatus OrderStatus { get; set; }
    public DeliveryStatus DeliveryStatus { get; set; }
    public LaundryStatus LaundryStatus { get; set; }

    #endregion Special attributes
}