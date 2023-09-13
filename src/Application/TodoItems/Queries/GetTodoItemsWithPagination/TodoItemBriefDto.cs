using SWD_Laundry_Backend.Application.Common.Mappings;
using SWD_Laundry_Backend.Domain.Entities;

namespace SWD_Laundry_Backend.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class TodoItemBriefDto : IMapFrom<TodoItem>
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}
