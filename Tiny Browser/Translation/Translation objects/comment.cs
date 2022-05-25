namespace Tiny_Browser.Translation.Translation_objects;

public class comment : ITagHandler
{
    public HtmlObjectBase GetObjectFromString(string objectString)
    {
        return new HtmlComment(objectString);
    }

    public string Tag => "!--";
    public string EndTag => "--";
}

public class HtmlComment : HtmlObjectBase
{
    public string CommentedString;

    public HtmlComment(string commentedString)
    {
        CommentedString = commentedString;
    }

    public override string ToString()
    {
        return "Hidden code.";
    }
}