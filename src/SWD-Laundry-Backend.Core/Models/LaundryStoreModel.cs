#nullable disable

namespace SWD_Laundry_Backend.Core.Models;

public class LaundryStoreModel
{
    public string StoreName { get; set; }
    public string Address { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool Status { get; set; }

    //public string Password { get; set; }
    //public string Email { get; set; }
    //public string PhoneNumber { get; set; }
}