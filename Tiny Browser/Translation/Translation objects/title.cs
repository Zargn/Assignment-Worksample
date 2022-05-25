using TinyHtmlReader;

namespace Tiny_Browser.Translation.Translation_objects;

public class title : ITagHandler
{
    public HtmlObjectBase GetObjectFromString(string objectString)
    {
        return new HtmlTitle(TranslationCollection.GetStringBetween(objectString, ">", "<"));
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
        return $"[Title]: {Title}";
    }

    public override void OnClick()
    {
        throw new NotImplementedException();
    }
}
