using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Laundry_Backend.Domain.Entities;

public class LaundryService : BaseAuditableEntity
{
    public double Price { get; set; }
    #region Relationship

    [ForeignKey(nameof(LaundryStore))]
    public int LaundryId { get; set; }

    [ForeignKey(nameof(LaundryStore))]
    public int ServiceId { get; set; }

    public LaundryStore? LaundryStore { get; set; }
    public Service? Service { get; set; }

    #endregion Relationship
}