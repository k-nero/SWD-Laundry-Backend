using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SWD_Laundry_Backend.Domain.Entities.Validation;

namespace SWD_Laundry_Backend.Domain.Entities;

#nullable disable

public class Staff_Trip : BaseAuditableEntity
{
    public string Address { get; set; }
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
    public decimal TripCollect { get; set; } = 0;

    #region Relationship

    [ForeignKey("Staff")]
    public int StaffID { get; set; }

    public Staff Staff { get; set; }

    #endregion Relationship

    #region Special Attribute

    private string _tripstatus;

    public string TripStatus
    {
        get { return _tripstatus; }
        set
        {
            _tripstatus = new Validate().IsValidTripStatus(value)
                ? value
                : throw new ArgumentException("Invalid trip status {FINISHED, PROCESSING, CANCELLED}.");
        }
    }

    #endregion Special Attribute
}