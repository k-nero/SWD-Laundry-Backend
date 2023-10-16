using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Core.Enum;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;


public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; }
    public TimeFrame DeliveryTimeFrame { get; set; }
    public DateTime ExpectedFinishDate { get; set; }

    //public OrderType OrderType { get; set; }
    public PaymentType PaymentType { get; set; }

    public short Amount { get; set; }
    public double TotalPrice { get; set; }
    public string? Address { get; set; } // Address = Customer's building location


    ////===========================
    [ForeignKey(nameof(Customer))]
    public string? CustomerID { get; set; }

    [ForeignKey(nameof(LaundryStore))]
    public string? LaundryStoreID { get; set; }

    [ForeignKey(nameof(Staff))]
    public string? StaffID { get; set; }

    ////===========================
    public Customer?  Customer { get; set; }

    public Staff? Staff { get; set; }
    public LaundryStore? LaundryStore { get; set; }

}