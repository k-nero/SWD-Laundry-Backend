namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Wallet : BaseAuditableEntity
{
    public double Balance { get; set; }

    #region Relationship

    public List<Transaction> Transactions { get; set; }
    public Customer Customer { get; set; }
    public LaundryStore LaundryStore { get; set; }
    public Staff Staff { get; set; }

    #endregion Relationship
}