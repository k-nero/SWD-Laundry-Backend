using System.Globalization;
using SWD_Laundry_Backend.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace SWD_Laundry_Backend.Infrastructure.Files.Maps;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}
