using System.ComponentModel.DataAnnotations.Schema;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;

#nullable disable

public class Staff_Trip : BaseEntity
{
    public int TripCollect { get; set; } = 0;

    #region Relationship

    [ForeignKey("Staff")]
    public string StaffID { get; set; }

    [ForeignKey("TimeSchedule")]
    public string TimeScheduleID { get; set; }

    [ForeignKey("Building")]
    public string BuildingID { get; set; }

    public Building Building { get; set; }
    public Staff Staff { get; set; }
    public TimeSchedule TimeSchedule { get; set; }

    #endregion Relationship

    #region Special Attribute

    public TripType TripType { get; set; }

    #endregion Special Attribute
}