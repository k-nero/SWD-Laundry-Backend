using System.ComponentModel.DataAnnotations.Schema;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class OrderHistory : BaseAuditableEntity
{
    #region Relationship

    [ForeignKey("Order")]
    public int OrderID { get; set; }

    public Order Order { get; set; }

    #endregion Relationship

    #region Special attributes

    public OrderStatus Status { get; set;}

    #endregion Special attributes
}