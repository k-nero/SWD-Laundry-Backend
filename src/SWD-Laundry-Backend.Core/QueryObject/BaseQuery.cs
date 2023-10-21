using Microsoft.AspNetCore.Mvc;

namespace SWD_Laundry_Backend.Core.QueryObject;
public record class BaseQuery
{
    [BindProperty(Name = "page", SupportsGet = true)]
    public int Page { get; init; }
    [BindProperty(Name = "limit", SupportsGet = true)]
    public int Limit { get; init; }
    [BindProperty(Name = "start-date", SupportsGet = true)]
    public DateTime? StartDate { get; init; }
    [BindProperty(Name = "end-date", SupportsGet = true)]
    public DateTime? EndDate { get; init; }
    [BindProperty(Name = "sort", SupportsGet = true)]
    public string? Sort { get; init; }
    [BindProperty(Name = "is-deleted", SupportsGet = true)]
    public bool IsDeleted { get; init; } = false;
}
