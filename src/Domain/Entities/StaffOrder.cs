using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class StaffOrder : BaseAuditableEntity
{
    public bool IsDone { get; set; }
    public StaffOrderType Type { get; set; }

    #region Relationship

    [ForeignKey("Staff")]
    public int StaffID { get; set; }

    [ForeignKey("Order")]
    public int OrderID { get; set; }

    public Staff Staff { get; set; }
    public Order Order { get; set; }

    #endregion Relationship
}