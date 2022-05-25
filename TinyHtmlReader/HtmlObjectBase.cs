namespace TinyHtmlReader;

public class HtmlObjectBase
{
    public readonly string Type;

    public HtmlObjectBase()
    {
        Type = GetType().FullName;
    }
}