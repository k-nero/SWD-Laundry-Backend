using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Domain.Entities.Validation;
using SWD_Laundry_Backend.Domain.IdentityModel;

namespace SWD_Laundry_Backend.Domain.Entities;

#nullable disable

public class Customer : BaseAuditableEntity
{
    public string Name { get; set; }
    //public string Address { get; set; }

    #region Relationship

    [ForeignKey("Building")]
    public int BuildingID { get; set; }

    [ForeignKey("Wallet")]
    public int WalletID { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public Building Building { get; set; }
    public Wallet Wallet { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    #endregion Relationship

    #region Special Attribute

    private string _email;

    private string _phone;

    public string Email
    {
        get { return _email; }
        set
        {
            _email = new Validate().IsValidEmail(value)
                ? value
                : throw new ArgumentException("Invalid email.");
        }
    }

    public string Phone
    {
        get { return _phone; }
        set
        {
            _phone = new Validate().IsValidPhone(value)
                ? value
                : throw new ArgumentException("Invalid phone (must be 9-10 numbers and start with 09 or 01).");
        }
    }

    #endregion Special Attribute
}