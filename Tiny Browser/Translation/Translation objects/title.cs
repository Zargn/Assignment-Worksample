namespace Tiny_Browser.Translation.Translation_objects;

public class title : ITagHandler
{
    public HtmlObjectBase GetObjectFromString(string objectString)
    {
        var startIndex = objectString.IndexOf(">", 1, StringComparison.Ordinal) + 1;
        var endIndex = objectString.IndexOf("<", startIndex, StringComparison.Ordinal);
        var title = objectString.Substring(startIndex, endIndex - startIndex);
        return new HtmlTitle(title);
    }

    public string Tag => "title";
    public string EndTag => "/" + Tag;
}



public class HtmlTitle : HtmlObjectBase
{
    public readonly string Title;

    public HtmlTitle(string title)
    {
        Title = title;
    }

    public override string ToString()
    {
        return Title;
    }
}
