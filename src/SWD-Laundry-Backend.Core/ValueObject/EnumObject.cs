namespace SWD_Laundry_Backend.Core.ValueObject;
public record EnumObject
{
    private string _key;
    private int _value;
    private string _v;

    public EnumObject(string key, int value, string v)
    {
        _key = key;
        _value = value;
        _v = v;
    }

    public string name { get; set; }
    public int value { get; set; }
    public string displayName { get; set; }
}
