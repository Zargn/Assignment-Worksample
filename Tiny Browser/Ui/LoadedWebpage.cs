using System.Text;
using Tiny_Browser.Networking;
using Tiny_Browser.Translation.Translation_objects;

namespace Tiny_Browser.Ui;

public class LoadedWebpage
{
    public List<HtmlHyperlink> Links = new();
    public string Title;

    public string WebPage;

    public LoadedWebpage(List<TinyBrowserHtmlObject> htmlElements)
    {
        int linkId = 0;
        
        var stringBuilder = new StringBuilder();
        
        foreach (var htmlElement in htmlElements)
        {
            
            
            switch (htmlElement)
            {
                case HtmlHyperlink htmlHyperlink:
                    Links.Add(htmlHyperlink);
                    htmlHyperlink.LinkId = linkId++;
                    break;
                case HtmlTitle htmlTitle:
                    Title = htmlTitle.Title;
                    break;
            }
            
            htmlElement.OnDraw();

            // if (htmlElement is HtmlHyperlink)
            //     outputString.Append($"\n[{linkId++}]{htmlElement}");
            // else
            //     outputString.Append($"\n{htmlElement}");
        }

        WebPage = stringBuilder.ToString();
    }

    
    /// <summary>
    /// Draw the website to the terminal.
    /// </summary>
    public void DrawPage()
    {
        Console.WriteLine(WebPage);
    }

    
    /// <summary>
    /// Modifies the supplied http11request to point to the selected link. 
    /// </summary>
    /// <param name="http11Request"></param>
    /// <param name="requestedLink"></param>
    /// <returns>true if successful</returns>
    public bool TryUpdateRequestBasedOnLink(Http11Request http11Request, int requestedLink)
    {
        if (requestedLink >= Links.Count)
            return false;

        Links[requestedLink].ModifyHttp11Request(http11Request);
        return true;
    }
}