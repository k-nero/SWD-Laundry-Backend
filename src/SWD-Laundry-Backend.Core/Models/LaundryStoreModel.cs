#nullable disable

namespace SWD_Laundry_Backend.Core.Models;

public class LaundryStoreModel
{
    public string ApplicationUserID { get; set; }

    public string Name { get; set; }
    public string Address { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool Status { get; set; }
}