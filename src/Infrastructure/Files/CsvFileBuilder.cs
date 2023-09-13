using System.Globalization;
using SWD_Laundry_Backend.Application.Common.Interfaces;
using SWD_Laundry_Backend.Application.TodoLists.Queries.ExportTodos;
using SWD_Laundry_Backend.Infrastructure.Files.Maps;
using CsvHelper;

namespace SWD_Laundry_Backend.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
