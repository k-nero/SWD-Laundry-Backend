using System.ComponentModel.DataAnnotations.Schema;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;

public class Payment : BaseEntity
{
    public double Price { get; set; }

    ////===========================
    [ForeignKey(nameof(Order))]
    public string OrderId { get; set; }

    public Order? Orders { get; set; }
}