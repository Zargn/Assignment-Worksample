namespace TinyHtmlReader;

public interface ITagHandler
{
    public HtmlObjectBase GetObjectFromString(string objectString);
    public string Tag { get; }
    public string EndTag { get; }
}