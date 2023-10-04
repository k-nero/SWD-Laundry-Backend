using SWD_Laundry_Backend.Core.Enum;

namespace SWD_Laundry_Backend.Core.Models;

public class StaffTripModel
{
    public int TripCollect { get; set; } = 0;

    public string? BuildingID { get; set; }
    public string? TimeScheduleID { get; set; }
    public string? StaffID { get; set; }
    public TripType TripType { get; set; }
}