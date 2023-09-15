using System.ComponentModel.DataAnnotations.Schema;
using SWD_Laundry_Backend.Domain.Entities.Validation;

namespace SWD_Laundry_Backend.Domain.Entities;

#nullable disable

public class StaffTrip : BaseAuditableEntity
{
    //public DateOnly TripDate { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int TripCollect { get; set; } = 0;
    

    /// <summary>
    /// Relationship
    /// </summary>
    ///
    [ForeignKey("Building")]
    public int BuildingID { get; set; }

    [ForeignKey("Staff")]
    public int StaffID { get; set; }

    public Building Building { get; set; }

    public Staff Staff { get; set; }

    /// <summary>
    /// Special attributes
    /// </summary>
    /// 
    private string _tripstatus;
    public string TripStatus
    {
        get { return _tripstatus; }
        set
        {
            _tripstatus = new Validate().IsValidTripStatus(value)
                ? value
                : throw new ArgumentException("Not valid trip status.");
        }
    }
}