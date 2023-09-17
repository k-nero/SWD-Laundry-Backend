using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Domain.Entities.Validation;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class OrderHistory : BaseAuditableEntity
{
    #region Relationship

    [ForeignKey("Order")]
    public int OrderID { get; set; }

    public Order Order { get; set; }

    #endregion Relationship

    #region Special attributes

    private string _orderstatus;

    public string Status
    {
        get { return _orderstatus; }
        set
        {
            _orderstatus = new Validate().IsValidTripStatus(value)
                ? value
                : throw new ArgumentException("Invalid order status {FINISHED, PROCESSING, CANCELLED}.");
        }
    }

    #endregion Special attributes
}