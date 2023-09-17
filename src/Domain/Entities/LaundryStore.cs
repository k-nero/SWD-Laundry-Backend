using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD_Laundry_Backend.Domain.Entities.Validation;
using SWD_Laundry_Backend.Domain.IdentityModel;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class LaundryStore : BaseAuditableEntity
{
    public string Address { get; set; }

    /// <summary>
    /// Relationship
    /// </summary>
    ///
    public string ApplicationUserID { get; set; }

    public int WalletID { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public Wallet Wallet { get; set; }

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