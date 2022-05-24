namespace Tiny_Browser.Translation;

public interface ITagHandler
{
    public HtmlObjectBase GetObjectFromString(string objectString);
    public string Tag { get; }
    public string EndTag { get; }
}