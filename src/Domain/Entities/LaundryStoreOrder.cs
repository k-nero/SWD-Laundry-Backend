using System.ComponentModel.DataAnnotations.Schema;

namespace SWD_Laundry_Backend.Domain.Entities;

public class LaundryStoreOrder : BaseAuditableEntity
#nullable disable
{
    public bool IsDone { get; set; }

    #region Relationship

    [ForeignKey("Order")]
    public int OrderID { get; set; }

    [ForeignKey("LaundryStore")]
    public int LaundryStoreID { get; set; }

    public LaundryStore LaundryStore { get; set; }
    public Order Order { get; set; }

    #endregion Relationship
}