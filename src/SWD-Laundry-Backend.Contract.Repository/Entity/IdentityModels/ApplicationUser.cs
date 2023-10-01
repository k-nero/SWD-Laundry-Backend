using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;

public class ApplicationUser : IdentityUser
{
#nullable disable
    public string Name { get; set; }

    #region Relationship

    [ForeignKey("Wallet")]
    public int WalletID { get; set; }

    public Wallet Wallet { get; set; }

    #endregion Relationship
}