namespace Tiny_Browser.Translation;

public class HtmlObjectBase
{
    public readonly string Type;

    public HtmlObjectBase()
    {
        Type = GetType().FullName;
    }
}

public enum HtmlObjectType
{
    Title,
}