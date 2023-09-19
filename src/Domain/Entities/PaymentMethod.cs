namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class PaymentMethod : BaseAuditableEntity
{
    public string Description { get; set; }

    #region Relationship

    public List<Order> Orders { get; set; }

    #endregion Relationship

    #region Special Attributes

    public PaymentType PaymentType { get; set; }

    #endregion Special Attributes
}