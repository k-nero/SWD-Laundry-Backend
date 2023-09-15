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
    public DateTime ShipDate { get; set; }
    public int Amount { get; set; }

    /// <summary>
    /// Relationship
    /// </summary>
    ///
    [ForeignKey("PaymentMethod")]
    public int PaymentMethodID { get; set; }

    [ForeignKey("Building")]
    public int BuildingID { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserID { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public Building Building { get; set; }
}