using Microsoft.AspNetCore.Mvc;

namespace SWD_Laundry_Backend.Core.QueryObject;
public record OrderHistoryQuery : BaseQuery
{
    [FromRoute(Name = "order-id")]
    public string? OrderId { get; init; }
    [FromQuery(Name = "customer-id")]
    public string? CustomerId { get; init; }
    [FromQuery(Name = "laundry-store-id")]
    public string? LaundryStoreId { get; init; }
}
