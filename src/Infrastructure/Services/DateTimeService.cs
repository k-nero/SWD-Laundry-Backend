using SWD_Laundry_Backend.Application.Common.Interfaces;

namespace SWD_Laundry_Backend.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
