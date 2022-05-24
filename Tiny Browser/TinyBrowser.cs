

using Tiny_Browser.Networking;

namespace Tiny_Browser;

public class Program { public static void Main() { new TinyBrowser().Run(); } }



public class TinyBrowser
{
    private const string DefaultRequest = "NOT IMPLEMENTED!";
    
    public void Run()
    {
        Console.WriteLine("Hello world!");
        TinyHttpClient tinyHttpClient = new();
        var hostname = AskUserForStringInput("Please enter hostname");
        var port = AskUserForIntegerInput("Please enter port number");
        var request = AskUserForStringInput("Please enter http request");
        tinyHttpClient.SendHttpRequest(hostname, port, request);
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