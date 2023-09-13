using SWD_Laundry_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SWD_Laundry_Backend.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
