using System.Text;
using Tiny_Browser.Networking;
using Tiny_Browser.Translation.Translation_objects;
using Tiny_Browser.Ui;
using TinyHtmlReader;

namespace Tiny_Browser;

public class Program { public static void Main() { new TinyBrowser().Run(); } }



public class TinyBrowser
{
    
    
    public void Run()
    {
        TranslationCollection translationCollection = new();
        HtmlReader htmlReader = new(translationCollection.TagHandlers);
        TinyHttpClient tinyHttpClient = new();
        
        
        var hostname = Utility.AskUserForStringInput("Please enter hostname");
        var port = Utility.AskUserForIntegerInput("Please enter port number");
        

        var result = tinyHttpClient.SendHttpRequest(hostname, port, new Http11Request("GET", "/", hostname).ToString());
        Console.WriteLine(result);

        List<TinyBrowserHtmlObject> htmlObjects = new();

        foreach (var htmlObjectBase in htmlReader.ExtractHtmlObjects(result))
        {
            htmlObjects.Add(htmlObjectBase as TinyBrowserHtmlObject);
        }

        var loadedPage = new LoadedWebpage(htmlObjects);

    }
}