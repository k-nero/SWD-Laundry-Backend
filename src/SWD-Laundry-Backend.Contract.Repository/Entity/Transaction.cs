using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Contract.Repository.Entity;
using SWD_Laundry_Backend.Contract.Repository.Enum;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;
#nullable disable

public class Transaction : BaseEntity
{
    public string PaymentMethod { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }

    #region Relationship

    [ForeignKey(nameof(Wallet))]
    public string WalletID { get; set; }

    public Wallet Wallet { get; set; }
    public List<Payment> Payments { get; set; }

    #endregion Relationship

    #region Special Attribute

    public AllowedTransactionType TransactionType { get; set; }

    //public OrderStatus Status { get; set; }

    #endregion Special Attribute
}