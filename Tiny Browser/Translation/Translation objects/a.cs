using Tiny_Browser.Networking;
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
    public int LinkId;

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

    public override string? GetDisplayString()
    {
        return $"[{LinkId}] {this}";
    }

    public void ModifyHttp11Request(Http11Request http11Request)
    {
        if (Url.Contains("//"))
        {
            // It is a external link
            http11Request.Headers["Host"] = TranslationCollection.GetStringBetween(Url, "//", "/");
            int startPos = Url.IndexOf("/", Url.IndexOf("//", StringComparison.Ordinal) + 2, StringComparison.Ordinal);
            http11Request.Path = Url.Substring(startPos);
        }
        else if (Url.Contains("../"))
        {
            Console.WriteLine(http11Request.Path);
            // It is a link to parent directory
            int cutIndex = http11Request.Path.LastIndexOf("/", http11Request.Path.Length - 2, StringComparison.Ordinal);
            var newPath = http11Request.Path.Substring(0, cutIndex + 1);
            http11Request.Path = newPath + Url.Substring(3);
            Console.WriteLine(http11Request.Path);
        }
        else if (Url == "./")
        {
            // It is a internal link to root
            http11Request.Path = "/";
        }
        else
        {
            // It is a internal link
            http11Request.Path += Url;
        }
    }
}