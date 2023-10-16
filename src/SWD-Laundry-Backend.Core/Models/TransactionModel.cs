using SWD_Laundry_Backend.Core.Enum;

namespace SWD_Laundry_Backend.Core.Models;

public class TransactionModel
{
    public string? PaymentID { get; set; }
    public string? WalletID { get; set; }
    public PaymentType PaymentType { get; set; }
    public AllowedTransactionType TransactionType { get; set; }
    public double Amount { get; set; }
    public TransactionStatus Status { get; set; }
    public string? Description { get; set; }

}