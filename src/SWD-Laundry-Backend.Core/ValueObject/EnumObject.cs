namespace SWD_Laundry_Backend.Core.ValueObject;
public record EnumObject
{ 

    public EnumObject(string _key, int _value, string _displayName)
    {
        name = _key;
        value = _value;
        displayName = _displayName;
    }

    public string name { get; set; }
    public int value { get; set; }
    public string displayName { get; set; }
}
