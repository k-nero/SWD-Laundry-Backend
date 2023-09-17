using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD_Laundry_Backend.Domain.Entities.Validation;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class OrderHistory : BaseAuditableEntity
{
    /// <summary>
    /// Relationship
    /// </summary>
    /// 
    [ForeignKey("Order")]
    public int OrderID { get; set; }

    public Order Order { get; set; }

    /// <summary>
    /// Special attributes
    /// </summary>
    /// 
    private string _orderstatus;

    public string Status
    {
        get { return _orderstatus; }
        set
        {
            _orderstatus = new Validate().IsValidTripStatus(value)
                ? value
                : throw new ArgumentException("Not valid order status.");
        }
    }
}