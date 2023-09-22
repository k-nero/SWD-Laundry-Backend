using System.ComponentModel.DataAnnotations.Schema;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Order : BaseAuditableEntity
{
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public TimeFrame TimeFrame { get; set; }
    public DateTime ExpectedFinishDate { get; set; }
    public string Address { get; set; } // Address = Customer's building location
    public short Amount { get; set; }

    public double TotalPrice { get; set; }

    #region Relationship

    [ForeignKey("PaymentMethod")]
    public int PaymentMethodID { get; set; }

    [ForeignKey("Customer")]
    public int CustomerID { get; set; }

    ////===========================
    public Customer Customer { get; set; }

    public PaymentMethod PaymentMethod { get; set; }
    public List<OrderHistory> OrderHistories { get; set; }
    public List<StaffOrder> StaffOrders { get; set; }
    //public LaundryStoreOrder LaundryStoreOrder { get; set; }

    #endregion Relationship

    #region Special Attribute

    public OrderType OrderType { get; set; }

    #endregion Special Attribute
}