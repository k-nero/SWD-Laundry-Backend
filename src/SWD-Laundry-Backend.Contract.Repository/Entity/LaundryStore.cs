using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;
#nullable disable

public class LaundryStore : BaseEntity
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

    public List<Order> Orders { get; set; }

    #endregion Relationship
}