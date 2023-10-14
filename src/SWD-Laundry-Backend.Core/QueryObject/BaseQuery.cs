using Microsoft.AspNetCore.Mvc;

namespace SWD_Laundry_Backend.Core.QueryObject;
public record class BaseQuery
{
    [FromQuery(Name = "page")]
    public int Page { get; init; }
    [FromQuery(Name = "limit")]
    public int Limit { get; init; }
    [FromQuery(Name = "start-date")]
    public DateTime? StartDate { get; init; }
    [FromQuery(Name = "end-date")]
    public DateTime? EndDate { get; init; }
    [FromQuery(Name = "sort")]
    public string? Sort { get; init; }

}
