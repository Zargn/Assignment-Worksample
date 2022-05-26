using System.Text;
using Tiny_Browser.Networking;
using Tiny_Browser.Translation.Translation_objects;
using Tiny_Browser.Ui;
using TinyHtmlReader;

namespace Tiny_Browser;

public class Program { public static void Main() { new TinyBrowser().Run(); } }



public class TinyBrowser
{
    private readonly TranslationCollection translationCollection = new();
    private readonly TinyHttpClient tinyHttpClient = new();
    private readonly HtmlReader htmlReader;
    

    public TinyBrowser()
    {
        htmlReader = new(translationCollection.TagHandlers);
    }
    
    public void Run()
    {
        var hostname = Utility.AskUserForStringInput("Please enter hostname");
        var port = Utility.AskUserForIntegerInput("Please enter port number");
        

        // var result = tinyHttpClient.SendHttpRequest(port, new Http11Request("GET", "/", hostname));
        // Console.WriteLine(result);
        //
        // List<TinyBrowserHtmlObject> htmlObjects = new();
        //
        // foreach (var htmlObjectBase in htmlReader.ExtractHtmlObjects(result))
        // {
        //     htmlObjects.Add(htmlObjectBase as TinyBrowserHtmlObject);
        // }
        //
        // var loadedPage = new LoadedWebpage(htmlObjects);

        var http11Request = new Http11Request("GET", "/", hostname);

        var page = GetWebPage(port, http11Request);
        page.DrawPage();

        if (page.TryUpdateRequestBasedOnLink(http11Request, 46))
        {
            var page2 = GetWebPage(port, http11Request);
            page2.DrawPage();
        }
    }

    private LoadedWebpage GetWebPage(int port, Http11Request http11Request)
    {
        var htmlResponse = tinyHttpClient.SendHttpRequest(port, http11Request);
        
        // Convert the base htmlobjects to the more specialized ones we use. They are actually already the more
        // specialized ones, but the output has to be the base ones to stay generic.
        List<TinyBrowserHtmlObject> htmlObjects = new();
        foreach (var htmlObjectBase in htmlReader.ExtractHtmlObjects(htmlResponse))
            htmlObjects.Add(htmlObjectBase as TinyBrowserHtmlObject);

        var loadedWebPage = new LoadedWebpage(new List<TinyBrowserHtmlObject>(htmlObjects));
        return loadedWebPage;
    }
}