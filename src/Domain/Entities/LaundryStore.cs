using System.ComponentModel.DataAnnotations.Schema;
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

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public ApplicationUser ApplicationUser { get; set; }

    public Wallet Wallet { get; set; }


    public virtual List<Service> Services  { get; set; }

    #endregion Relationship
}