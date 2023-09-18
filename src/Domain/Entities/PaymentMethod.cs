namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class PaymentMethod : BaseAuditableEntity
{
    public string Description { get; set; }

    /// <summary>
    /// Special attributes
    /// </summary>
    //private string _type;

    //public string PaymentType
    //{
    //    get { return _type; }
    //    set
    //    {
    //        _type = new Validate().IsValidPayment(value)
    //            ? value
    //            : throw new ArgumentException("Invalid payment type{CASH , PAYPAL}.");
    //    }
    //}
    public PaymentType PaymentType { get; set; }
}