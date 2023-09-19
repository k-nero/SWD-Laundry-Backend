namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class PaymentMethod : BaseAuditableEntity
{
    public string Description { get; set; }

    #region Relationship

    public List<Order> Orders { get; set; }

    #endregion Relationship

    #region Special Attributes


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
    public string Name { get; set; }
}