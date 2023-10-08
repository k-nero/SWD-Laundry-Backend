using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;

public class ApplicationUser : IdentityUser
{

    public string? Name { get; set; }

    public string? ImageUrl { get; set; }

    #region Relationship

    [ForeignKey("Wallet")]
    public string? WalletID { get; set; }


    public Wallet? Wallet { get; set; }

    #endregion Relationship
}