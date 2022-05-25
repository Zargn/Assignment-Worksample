using System.Text;
using Tiny_Browser.Networking;
using Tiny_Browser.Translation;
using Tiny_Browser.Translation.Translation_objects;

namespace Tiny_Browser;

public class Program { public static void Main() { new TinyBrowser().Run(); } }



public class TinyBrowser
{
    
    
    public void Run()
    {
        TranslationCollection translationCollection = new();
        HtmlSerializer htmlSerializer = new(translationCollection.TagHandlers);
        TinyHttpClient tinyHttpClient = new();
        
        var hostname = AskUserForStringInput("Please enter hostname");
        var port = AskUserForIntegerInput("Please enter port number");

        var result = tinyHttpClient.SendHttpRequest(hostname, port);
        Console.WriteLine(result);

        var outputString = new StringBuilder();
        
        foreach (var htmlObjectBase in htmlSerializer.ExtractHtmlObjects(result))
        {
            var type = AppDomain
                .CurrentDomain.GetAssemblies()
                .Select(assembly => assembly.GetType(htmlObjectBase.Type))
                .SingleOrDefault(type => type != null);

            var htmlObject = Convert.ChangeType(htmlObjectBase, type);
            outputString.Append($"\n{htmlObject}");
        }

        Console.WriteLine(outputString);
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