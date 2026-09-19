namespace JsonUnionTypes;

public union StringOrNumber(string, long)
{
    public string? StringValue => this switch
    {
        string stringValue => stringValue,
        long longValue => longValue.ToString(),
        null => null
    };
}
