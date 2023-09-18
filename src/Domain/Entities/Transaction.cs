using SWD_Laundry_Backend.Domain.Entities.Validation;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Transaction : BaseAuditableEntity
{
    public string PaymentMethod { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }

    #region Relationship

    public int WalletID { get; set; }

    public List<Wallet> Wallet { get; set; }

    #endregion Relationship

    #region Special Attribute

    //private string _transactiontype;

    //public string TransactionType
    //{
    //    get { return _transactiontype; }
    //    set
    //    {
    //        if (!new Validate().IsValidTransactionType(value))
    //            throw new ArgumentException("Invalid transaction type {DEPOSIT, WITHDRAWAL, DEBT, PAID}.");
    //        _transactiontype = value;
    //    }
    //}

    public AllowedTransactionType TransactionType { get; set; }

    public Status Status { get; set;}

    #endregion Special Attribute
}