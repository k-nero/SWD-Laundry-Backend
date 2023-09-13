using SWD_Laundry_Backend.Application.TodoLists.Queries.ExportTodos;

namespace SWD_Laundry_Backend.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
