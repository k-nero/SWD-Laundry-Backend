#nullable disable

using System.ComponentModel.DataAnnotations.Schema;

namespace SWD_Laundry_Backend.Core.Models;

public class LaundryStoreModel
{
    public string ApplicationUserID { get; set; }

    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool Status { get; set; }
}