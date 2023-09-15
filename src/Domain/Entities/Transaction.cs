using SWD_Laundry_Backend.Domain.Entities.Validation;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Transaction : BaseAuditableEntity
{
    public string PaymentMethod { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }

    /// <summary>
    /// Relationship
    /// </summary>
    /// 
    public int WalletID { get; set; }

    public List<Wallet> Wallet { get; set; }

    /// <summary>
    /// Special attribute
    /// </summary>
    /// 
    private string _transactiontype;

    private string _status;

    public string TransactionType
    {
        get { return _transactiontype; }
        set
        {
            if (!new Validate().IsValidTransactionType(value))
                throw new ArgumentException("Not valid transaction type.");
            _transactiontype = value;
        }
    }

    public string Status
    {
        get { return _status; }
        set
        {
            if (!new Validate().IsValidTransactionStatus(value))
                throw new ArgumentException("Not valid transaction status.");
            _status = value;
        }
    }
}