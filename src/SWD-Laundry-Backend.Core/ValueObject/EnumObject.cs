namespace SWD_Laundry_Backend.Core.ValueObject;
public record EnumObject
{ 

    public EnumObject(string key, int value, string v)
    {
        name = key;
        value = value;
        displayName = v;
    }

    public string name { get; set; }
    public int value { get; set; }
    public string displayName { get; set; }
}
