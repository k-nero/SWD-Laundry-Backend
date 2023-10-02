using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;

#nullable disable

public class Customer : BaseEntity
{
    //public string Name { get; set; }
    //public string Address { get; set; }

    #region Relationship

    [ForeignKey("Building")]
    public string BuildingID { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public Building Building { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public virtual List<Order> Order { get; set; }

    #endregion Relationship

    #region Special Attribute

  

    #endregion Special Attribute
}