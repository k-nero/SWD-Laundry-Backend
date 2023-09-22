using SWD_Laundry_Backend.Domain.IdentityModel;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Wallet : BaseAuditableEntity
{
    public double Balance { get; set; }

    #region Relationship

    public List<Transaction> Transactions { get; set; }

    public ApplicationUser ApplicationUser { get; set; }

    #endregion Relationship
}