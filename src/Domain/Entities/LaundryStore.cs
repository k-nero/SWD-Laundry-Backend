using SWD_Laundry_Backend.Domain.Entities.Validation;
using SWD_Laundry_Backend.Domain.IdentityModel;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class LaundryStore : BaseAuditableEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool Status { get; set; }

    #region Relationship

    public string ApplicationUserID { get; set; }

    public int WalletID { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public Wallet Wallet { get; set; }

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