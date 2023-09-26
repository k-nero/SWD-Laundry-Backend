using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Domain.IdentityModel;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Order : BaseAuditableEntity
{
    public DateTime OrderDate { get; set; } = DateTime.Now;

    public DateTime ShipDate { get; set; }

    public DateTime ExpectedFinishDate { get; set; }
    public string Address { get; set; } // Address = Customer's building location
    public short Amount { get; set; }

    public double TotalPrice { get; set; }

    #region Relationship

    [ForeignKey("PaymentMethod")]
    public int PaymentMethodID { get; set; }

    [ForeignKey("Customer")]
    public int CustomerID { get; set; }

    //[ForeignKey("LaundryStore")]
    //public int LaundryStoreID { get; set; }

    ////[ForeignKey("Staff")]
    ////public int StaffID { get; set; }

    //[ForeignKey("Service")]
    //public int ServiceID { get; set; }

    ////===========================
    //public Service Service { get; set; }

    public virtual LaundryStore LaundryStore { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Staff Staff { get; set; }

    public PaymentMethod PaymentMethod { get; set; }
    public List<OrderHistory> OrderHistories { get; set; }

    #endregion Relationship

    #region Special Attribute

    public OrderType OrderType { get; set; }

    #endregion Special Attribute
}