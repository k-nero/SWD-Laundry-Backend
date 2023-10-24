using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Core.QueryObject;

namespace SWD_Laundry_Backend.Core.Models.Common;
public class PaginatedList<T>
{
    public IReadOnlyCollection<T> Items { get; }
    public int PageNumber { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }

    public PaginatedList(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalPages = (int)Math.Ceiling(pageSize == 0 ? 0 : count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

    public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, BaseQuery query)
    {
        if (query.StartDate != null)
        {
            DateTimeOffset? startDate = DateTime.SpecifyKind(query.StartDate.Value, DateTimeKind.Utc);
            ParameterExpression xParam = Expression.Parameter(typeof(T), "x");
            MemberExpression createdTimeProperty = Expression.Property(xParam, "CreatedTime");
            if(createdTimeProperty != null)
            {
                BinaryExpression comparison = Expression.GreaterThanOrEqual(createdTimeProperty, Expression.Constant(startDate, typeof(DateTimeOffset?)));
                Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(comparison, xParam);
                source = source.Where(expression);
            }
            else
            {
                throw new Exception("Unsupported type: CreatedTime property not found !!!");
            }
        }

        if (query.EndDate != null)
        {
            DateTimeOffset? endDate = DateTime.SpecifyKind(query.EndDate.Value.AddMilliseconds(86399000), DateTimeKind.Utc);
            ParameterExpression xParam = Expression.Parameter(typeof(T), "x");
            MemberExpression createdTimeProperty = Expression.Property(xParam, "CreatedTime");
            if(createdTimeProperty != null)
            {
                BinaryExpression comparison = Expression.LessThanOrEqual(createdTimeProperty, Expression.Constant(endDate, typeof(DateTimeOffset?)));
                Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(comparison, xParam);
                source = source.Where(expression);
            }
            else
            {
                throw new Exception("Unsupported type: CreatedTime property not found !!!");
            }
        }

        if(query.Sort == null)
        {
            ParameterExpression xParam = Expression.Parameter(typeof(T), "x");
            MemberExpression createdTimeProperty = Expression.Property(xParam, "CreatedTime");
            if(createdTimeProperty != null)
            {
                Expression<Func<T, DateTimeOffset?>> expression = Expression.Lambda<Func<T, DateTimeOffset?>>(createdTimeProperty, xParam);
                source = source.OrderByDescending(expression);
            }
            else
            {
                throw new Exception("Unsupported type: CreatedTime property not found !!!");
            }
        }

        var count = await source.CountAsync();
        count = count == int.MaxValue ? 0 : count == int.MinValue ? 0 : count;
        int page = query.Page <= 0 ? 1 : query.Page;
        int limit = query.Limit <= 0 ? count : query.Limit;
        var items = await source.Skip((page - 1) * limit).Take(limit).ToListAsync();
        return new PaginatedList<T>(items, count, page, limit);
    }
}
