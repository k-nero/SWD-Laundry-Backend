using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Core.Enum;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;


public class Transaction : BaseEntity
{
    public PaymentType PaymentType { get; set; }
    public AllowedTransactionType TransactionType { get; set; }
    public double Amount { get; set; }
    public TransactionStatus Status { get; set; }
    public string? Description { get; set; }

    ////===========================
    [ForeignKey(nameof(Wallet))]
    public string? WalletID { get; set; }

    public Wallet? Wallet { get; set; }

    [ForeignKey(nameof(Payment))]
    public string? PaymentID { get; set; }
    public Payment? Payment { get; set; }
    //public List<Payment> Payments { get; set; }
}