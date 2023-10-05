using Newtonsoft.Json;

namespace SWD_Laundry_Backend.Core.Utils;
public class StringEnumConverterPair : JsonConverter
{


    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("name");
        writer.WriteValue(value.ToString());
        writer.WritePropertyName("value");
        writer.WriteValue(Convert.ChangeType(value, typeof(int)));
        writer.WriteEndObject();
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        // ill leave this up to your imagination
        throw new NotImplementedException();
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(System.Enum);
    }

}
