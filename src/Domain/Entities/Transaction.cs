using SWD_Laundry_Backend.Domain.Entities.Validation;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Transaction : BaseAuditableEntity
{
    public string PaymentMethod { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }

    #region Relationship

    public int WalletID { get; set; }

    public List<Wallet> Wallet { get; set; }

    #endregion Relationship

    #region Special Attribute

    private string _transactiontype;

    private string _status;

    public string TransactionType
    {
        get { return _transactiontype; }
        set
        {
            if (!new Validate().IsValidTransactionType(value))
                throw new ArgumentException("Invalid transaction type {DEPOSIT, WITHDRAWAL, DEBT, PAID}.");
            _transactiontype = value;
        }
    }

    public string Status
    {
        get { return _status; }
        set
        {
            if (!new Validate().IsValidTransactionStatus(value))
                throw new ArgumentException("Invalid transaction status {FINISHED, PROCESSING, CANCELLED}.");
            _status = value;
        }
    }

    #endregion Special Attribute
}