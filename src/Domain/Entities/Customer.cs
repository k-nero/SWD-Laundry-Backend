using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using SWD_Laundry_Backend.Domain.Entities.Validation;
using SWD_Laundry_Backend.Domain.IdentityModel;

namespace SWD_Laundry_Backend.Domain.Entities;

#nullable disable

public class Customer : BaseAuditableEntity
{
    public string Address { get; set; }

    /// <summary>
    /// Relationship
    /// </summary>
    ///
    [ForeignKey("Wallet")]
    public int WalletID { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public Wallet Wallet { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    /// <summary>
    /// Special attributes
    /// </summary>
    ///
    private string _email;

    private string _phone;

    public string Email
    {
        get { return _email; }
        set
        {
            _email = new Validate().IsValidEmail(value)
                ? value
                : throw new ArgumentException("Not valid mail.");
        }
    }

    public string Phone
    {
        get { return _phone; }
        set
        {
            _phone = new Validate().IsValidPhone(value)
                ? value
                : throw new ArgumentException("Not valid phone.");
        }
    }
}