using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Domain.Entities.Validation;
using SWD_Laundry_Backend.Domain.IdentityModel;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Staff : BaseAuditableEntity
{
    //public DateTime Dob { get; set; }
    //public string Address { get; set; }
    public double Salary { get; set; }

    #region Relationship

    [ForeignKey("Wallet")]
    public int WalletID { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public Wallet Wallet { get; set; }

    public List<Order> Order { get; set; }
    public List<Staff_Trip> Staff_Trips { get; set; }

    #endregion Relationship

    #region Special Attribute

    public StaffRole StaffRole { get; set; }

    #endregion Special Attribute
}