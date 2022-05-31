using Tiny_Browser.Networking;
using Tiny_Browser.Translation.Translation_objects;
using Tiny_Browser.Ui;
using TinyHtmlReader;
using ConsoleUtils;

namespace Tiny_Browser;

public class Program { public static void Main() { new TinyBrowser().Run(); } }



public class TinyBrowser
{
    private readonly TranslationCollection translationCollection = new();
    private readonly TinyHttpClient tinyHttpClient = new();
    private readonly HtmlReader htmlReader;

    private readonly Stack<LoadedWebpage> webPageHistory = new();
    private Stack<LoadedWebpage> goBackHistory = new();
    private LoadedWebpage currentLoadedWebpage;


    private int port;
    
    public TinyBrowser()
    {
        htmlReader = new(translationCollection.TagHandlers);
    }

    public void Run()
    {
        var hostname = Utility.AskUserForStringInput("Please enter hostname");
        port = Utility.AskUserForIntegerInput("Please enter port number");

        var http11Request = new Http11Request("GET", "/", hostname);
        
        
        var page = GetWebPage(http11Request);
        page.DrawPage(); 
        currentLoadedWebpage = page;

        
        while (true)
        {
            currentLoadedWebpage.DrawPage();
            switch (Utility.AskUserForStringInput("Enter selection. [U] = link selection, [Q] = quit, [B] = back, [F] = forward"))
            {
                case "U":
                    if (TryGetWebpage(currentLoadedWebpage, http11Request, out LoadedWebpage newPage))
                    {
                        webPageHistory.Push(currentLoadedWebpage);
                        currentLoadedWebpage = newPage;
                    }
                    else
                    {
                        Console.WriteLine("Could not find webpage...");
                    }
                    break;
                case "Q":
                    return;
                case "B":
                    GoBack();
                    break;
                case "F":
                    GoForward();
                    break;
                    
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }

    private void GoBack()
    {
        if (webPageHistory.Count == 0)
        {
            Console.WriteLine("History is empty, go to a new page to be able to go back!");
            return;
        }
        
        goBackHistory.Push(currentLoadedWebpage);
        currentLoadedWebpage = webPageHistory.Pop();
    }

    private void GoForward()
    {
        if (goBackHistory.Count == 0)
        {
            Console.WriteLine("Can't go further forward as this is the end of the history.");
            return;
        }
        
        webPageHistory.Push(currentLoadedWebpage);
        currentLoadedWebpage = goBackHistory.Pop();
    }

    private bool TryGetWebpage(LoadedWebpage currentPage, Http11Request http11Request, out LoadedWebpage newPage)
    {
        var number = Utility.AskUserForIntegerInput("Please enter id of link to open");
        newPage = null;
        if (currentPage.TryUpdateRequestBasedOnLink(http11Request, number))
        {
            newPage = GetWebPage(http11Request);
            return true;
        }

        return false;
    }

    private LoadedWebpage GetWebPage(Http11Request http11Request)
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