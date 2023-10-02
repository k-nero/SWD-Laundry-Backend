using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;



#nullable disable

public class Staff : BaseEntity
{
    //public DateTime Dob { get; set; }
    //public string Address { get; set; }
    //public double Salary { get; set; }

    #region Relationship

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public ApplicationUser ApplicationUser { get; set; }

    public List<Staff_Trip> Staff_Trips { get; set; }

    #endregion Relationship
}