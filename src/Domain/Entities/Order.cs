using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD_Laundry_Backend.Domain.Entities.Validation;
using SWD_Laundry_Backend.Domain.IdentityModel;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class Order : BaseAuditableEntity
{

    public DateTime OrderDate { get; set; }
    public DateTime ExpectedFinishDate { get; set; }
    public string Address { get; set; } // Address = Customer's building location
    public short Amount { get; set; }
    public bool IsWhiteClothes { get; set; }
    public double TotalPrice { get; set; }

    #region Relationship

    [ForeignKey("PaymentMethod")]
    public int PaymentMethodID { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public PaymentMethod PaymentMethod { get; set; }

    #endregion Relationship

    #region Special Attribute

    private string _orderType;

    public string OrderType
    {
        get => _orderType;
        set
        {
            _orderType = new Validate().IsValidOrderType(value)
                ? value
                : throw new Exception("Invalid order type {ONEWAY, TWOWAY}");
        }
    }

    #endregion Special Attribute
}