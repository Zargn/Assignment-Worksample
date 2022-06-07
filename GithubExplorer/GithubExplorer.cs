using ConsoleUtils;
using GithubExplorer.GithubObjects;
using GithubExplorer.Interfaces;
using GithubExplorer.Networking;

namespace GithubExplorer;

public class Program { public static void Main() { new GithubExplorer().Run(); } }

public class GithubExplorer
{
    public void Run()
    {
//         var targetUser = Utility.AskUserForStringInput(@"Welcome to this very limited github browser!
// Please enter a user you like to inspect!");

        IHttpClient httpClient = new HttpConnection();
        IGithubAPI githubApi = new GithubAPI(httpClient);
        
        var user = githubApi.GetUser("projectmesa");
        user.Draw();
        Utility.PrintConsoleBuffer();

        // var targetRepository = Utility.AskUserForStringInput("Write repository name to open:");

        var repositories = user.Repositories;
        foreach (var VARIABLE in repositories)
        {
            VARIABLE.Draw();
        }
        Utility.PrintConsoleBuffer();

        Console.WriteLine("-------------------");
        if (user.TryGetRepository("mesa", out IRepository repository))
        {
            repository.Draw();
            var i = repository.Issues;
            foreach (var VARIABLE in i)
            {
                VARIABLE.Draw();
            }
            Utility.PrintConsoleBuffer();
        }
        else
        {
            Console.WriteLine("not found");
        }
    }
}