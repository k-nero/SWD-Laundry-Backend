using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SWD_Laundry_Backend.Domain.Entities.Validation;

namespace SWD_Laundry_Backend.Domain.Entities;

#nullable disable

public class Staff_Trip : BaseAuditableEntity
{
    public int TripCollect { get; set; } = 0;

    #region Relationship

    [ForeignKey("Staff")]
    public int StaffID { get; set; }

    [ForeignKey("TimeSchedule")]
    public int TimeScheduleID { get; set; }

    [ForeignKey("Building")]
    public int BuildingID { get; set; }

    public Building Building { get; set; }
    public Staff Staff { get; set; }
    public TimeSchedule TimeSchedule { get; set; }

    #endregion Relationship

    #region Special Attribute

    public OrderStatus TripStatus { get; set; }

    #endregion Special Attribute
}