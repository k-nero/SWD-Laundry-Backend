using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;

public class Customer : BaseEntity
{
    [ForeignKey("Building")]
    public string BuildingID { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    ////===========================
    public Building? Building { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
    //public virtual List<Order> Order { get; set; }
}