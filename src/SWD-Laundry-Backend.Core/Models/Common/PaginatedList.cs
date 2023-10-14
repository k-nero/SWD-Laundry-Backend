using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Core.QueryObject;

namespace SWD_Laundry_Backend.Core.Models.Common;
public class PaginatedList<T>
{
    public IReadOnlyCollection<T> Items { get; }
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public PaginatedList(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, BaseQuery query)
    {
        var count = await source.CountAsync();
        int page = query.Page <= 0 ? 1 : query.Page;
        int limit = query.Limit <= 0 ? count : query.Limit;
        var items = await source.Skip((page - 1) * limit).Take(limit).ToListAsync();
        return new PaginatedList<T>(items, count, page, limit);
    }
}
