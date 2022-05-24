namespace Tiny_Browser.Translation.Translation_objects;

public class title : ITagHandler
{
    public HtmlObjectBase GetObjectFromString(string objectString)
    {
        throw new NotImplementedException();
    }

    public string Tag { get; }
    public string EndTag { get; }
}



public class HtmlTitle : HtmlObjectBase
{
    public readonly string Title;

    public HtmlTitle(string title)
    {
        Title = title;
    }
}
