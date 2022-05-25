using TinyHtmlReader;

namespace Tiny_Browser.Translation.Translation_objects;

public class TranslationCollection
{
    public List<ITagHandler> TagHandlers = new();
    
    public TranslationCollection()
    {
        TagHandlers.Add(new title());
        TagHandlers.Add(new a());
        TagHandlers.Add(new comment());
    }

    public static string GetStringBetween(string baseString, string firstString, string secondString)
    {
        var startIndex = baseString.IndexOf(firstString, 1, StringComparison.Ordinal) + firstString.Length;
        var endIndex = baseString.IndexOf(secondString, startIndex, StringComparison.Ordinal);
        var title = baseString.Substring(startIndex, endIndex - startIndex);
        return title;
    }
}

public abstract class TinyBrowserHtmlObject : HtmlObjectBase
{
    /// <summary>
    /// Called when the user clicks this html object.
    /// </summary>
    public abstract void OnClick();
    
    /// <summary>
    /// Called once when the page is loaded.
    /// </summary>
    public abstract void OnDraw();
}