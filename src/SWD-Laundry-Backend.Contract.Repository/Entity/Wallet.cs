using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Entity.IdentityModels;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;
#nullable disable

public class Wallet : BaseEntity
{
    public double Balance { get; set; }

    #region Relationship

    public List<Transaction> Transactions { get; set; }

    public ApplicationUser ApplicationUser { get; set; }

    #endregion Relationship
}