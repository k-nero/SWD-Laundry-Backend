using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Enum;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;
#nullable disable

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public TimeFrame DeliveryTimeFrame { get; set; }
    public DateTime ExpectedFinishDate { get; set; }
    public string Address { get; set; } // Address = Customer's building location
    public short Amount { get; set; }

    public double TotalPrice { get; set; }

    #region Relationship

    [ForeignKey("Customer")]
    public int CustomerID { get; set; }

    [ForeignKey(nameof(LaundryStore))]
    public int LaundryStoreID { get; set; }

    [ForeignKey(nameof(Staff))]
    public int StaffID { get; set; }

    ////===========================
    public Customer Customer { get; set; } 
    public Staff Staff { get; set; }
    public LaundryStore LaundryStore { get; set; }

    public List<Payment> Payments { get; set; }
    public List<OrderHistory> OrderHistories { get; set; }

    #endregion Relationship

    #region Special Attribute

    public OrderType OrderType { get; set; }
    public PaymentType PaymentType { get; set; }

    #endregion Special Attribute
}