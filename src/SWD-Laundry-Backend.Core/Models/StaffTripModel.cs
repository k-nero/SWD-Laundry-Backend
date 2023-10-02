using SWD_Laundry_Backend.Core.Enum;

namespace SWD_Laundry_Backend.Core.Models;

public class StaffTripModel
{
    public int TripCollect { get; set; } = 0;
    
    public BuildingModel? Building { get; set; } // Name of the associated building
    public string? StaffName { get; set; } // Name of the associated staff
    public TimeScheduleModel? TimeSchedule { get; set; } // Name of the associated time schedule
    public TripType TripType { get; set; }
}