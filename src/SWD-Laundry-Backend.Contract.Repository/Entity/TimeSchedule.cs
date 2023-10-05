using SWD_Laundry_Backend.Core.Enum;

namespace SWD_Laundry_Backend.Contract.Repository.Entity;
#nullable disable

public class TimeSchedule : BaseEntity
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public DayOfWeek DayOfWeek { get; set; }
    public TimeFrame TimeFrame { get; set; }
    //public virtual List<Staff_Trip> Staff_Trip { get; set; }
}