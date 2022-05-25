using TinyHtmlReader;

namespace Tiny_Browser.Translation.Translation_objects;

public class a : ITagHandler
{
    public HtmlObjectBase GetObjectFromString(string objectString)
    {
        var url = TranslationCollection.GetStringBetween(objectString, "href=\"", "\"");

        var description = TranslationCollection.GetStringBetween(objectString, ">", "</a>");
        return new HtmlHyperlink(url, description);
    }

    public string Tag => "a";
    public string EndTag => "/" + Tag;
}

public class HtmlHyperlink : TinyBrowserHtmlObject
{
    public readonly string Url;
    public readonly string Description;

    public HtmlHyperlink(string url, string description)
    {
        Url = url;
        Description = description;
    }

    public override string ToString()
    {
        return $"[HyperLink]: {Url} [Description]: \"{Description}\"";
    }

    public override void OnClick()
    {
        throw new NotImplementedException();
    }

    public override void OnDraw()
    {
        throw new NotImplementedException();
    }
}