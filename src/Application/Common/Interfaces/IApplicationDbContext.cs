using SWD_Laundry_Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SWD_Laundry_Backend.Domain.Common;

namespace SWD_Laundry_Backend.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<T> Get<T>() where T : BaseAuditableEntity;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
