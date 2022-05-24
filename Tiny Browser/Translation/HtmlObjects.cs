namespace Tiny_Browser.Translation;

public class HtmlObject
{
    public HtmlObjectType Type;

    public HtmlObject(HtmlObjectType type)
    {
        Type = type;
    }
}

public class HtmlObject<T> : HtmlObject
{ 
    public T Value;

    public HtmlObject(HtmlObjectType type, T value) : base(type)
    {
        Value = value;
    }
}

public enum HtmlObjectType
{
    Title
}