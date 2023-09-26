using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Domain.IdentityModel;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Staff : BaseAuditableEntity
{
    public DateTime Dob { get; set; }
    public string Address { get; set; }
    public double Salary { get; set; }

    #region Relationship

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public ApplicationUser ApplicationUser { get; set; }

    public List<Staff_Trip> Staff_Trips { get; set; }
    public List<StaffOrder> StaffOrders { get; set; }

    #endregion Relationship
}