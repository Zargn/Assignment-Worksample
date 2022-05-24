

using Tiny_Browser.Networking;
using Tiny_Browser.Translation;
using Tiny_Browser.Translation.Translation_objects;

namespace Tiny_Browser;

public class Program { public static void Main() { new TinyBrowser().Run(); } }



public class TinyBrowser
{
    private const string DefaultRequest = "GET / HTTP/1.1\r\nHost: www.acme.com\r\n\r\n"; //"{command} {uri} {protocol-version}\r\n{header-key}: {header-value}\r\n{header-key}: {header-value}\r\n\r\n"
    
    public void Run()
    {
        TranslationCollection translationCollection = new();
        HtmlSerializer htmlSerializer = new(translationCollection.TagHandlers);

        
        
        
        Console.WriteLine("Hello world!");
        TinyHttpClient tinyHttpClient = new();
        var hostname = AskUserForStringInput("Please enter hostname");
        var port = AskUserForIntegerInput("Please enter port number");
        // var request = AskUserForStringInput("Please enter http request");
        var result = tinyHttpClient.SendHttpRequest(hostname, port, DefaultRequest);
        // Console.WriteLine(result);

        foreach (var htmlObjectBase in htmlSerializer.ExtractHtmlObjects(result))
        {
            var type = AppDomain
                .CurrentDomain.GetAssemblies()
                .Select(assembly => assembly.GetType(htmlObjectBase.Type))
                .SingleOrDefault(type => type != null);

            // Console.WriteLine("Hi found object");
            // Console.WriteLine(type);

            var htmlObject = Convert.ChangeType(htmlObjectBase, type);
            Console.WriteLine(htmlObject);
        }
    }

    
    
    private string AskUserForStringInput(string question)
    {
        Console.WriteLine(question + " :");
        return Console.ReadLine();
    }

    private int AskUserForIntegerInput(string question)
    {
        while (true)
        {
            try
            {
                var inputString = AskUserForStringInput(question);
                var inputInteger = Int32.Parse(inputString);
                return inputInteger;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect format! Only numbers are allowed. Please try again.");
            }
        }
    }
}