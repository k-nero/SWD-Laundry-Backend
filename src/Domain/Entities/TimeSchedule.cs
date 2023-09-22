namespace SWD_Laundry_Backend.Domain.Entities;
#nullable disable

public class TimeSchedule : BaseAuditableEntity
{ 
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    #region Special Attribute

    public DayOfWeek DayOfWeek { get; set; }
    public TimeFrame TimeFrame { get; set; }
    public List<Staff_Trip> Staff_Trip { get; set; }

    #endregion Special Attribute
}