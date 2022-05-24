namespace Tiny_Browser.Translation;

public class HtmlObject
{
    public HtmlObjectType HtmlObjectType;
    public string Value;

    public HtmlObject(HtmlObjectType htmlObjectType, string value)
    {
        HtmlObjectType = htmlObjectType;
        Value = value;
    }
}

public enum HtmlObjectType
{
    Title
}