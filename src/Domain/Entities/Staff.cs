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


    [ForeignKey("Wallet")]
    public int WalletID { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public Wallet Wallet { get; set; }

    #endregion Relationship

    #region Special Attribute

    public StaffRole StaffRole { get; set; }

    //private string _email;

    //private string _phone;
    //private string _role;

    //public string Role
    //{
    //    get { return _role; }
    //    set
    //    {
    //        _role = new Validate().IsValidStaffRole(value)
    //            ? value
    //            : throw new ArgumentException("Invalid staff role {COLLECTOR, RECEIVER}.");
    //    }
    //}

    //public string Email
    //{
    //    get { return _email; }
    //    set
    //    {
    //        _email = new Validate().IsValidEmail(value)
    //            ? value
    //            : throw new ArgumentException("Invalid email.");
    //    }
    //}

    //public string Phone
    //{
    //    get { return _phone; }
    //    set
    //    {
    //        _phone = new Validate().IsValidPhone(value)
    //            ? value
    //            : throw new ArgumentException("Invalid phone (must be 9-10 numbers and start with 09 or 01).");
    //    }
    //}

    #endregion Special Attribute
}