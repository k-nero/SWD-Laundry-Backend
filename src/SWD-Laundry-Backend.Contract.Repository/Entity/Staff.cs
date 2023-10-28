using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;

public class Staff : BaseEntity
{
    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }

}