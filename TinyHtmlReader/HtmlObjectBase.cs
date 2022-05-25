namespace TinyHtmlReader;

public abstract class HtmlObjectBase
{
    public readonly string Type;

    public HtmlObjectBase()
    {
        Type = GetType().FullName;
    }

    public abstract void OnClick();
}