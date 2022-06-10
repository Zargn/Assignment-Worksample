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
        
        var user = githubApi.GetUser("Zargn");
        user.Draw();
        TurboOutput.PrintBuffer();

        // var targetRepository = Utility.AskUserForStringInput("Write repository name to open:");

        var repositories = user.Repositories;
        foreach (var VARIABLE in repositories)
        {
            VARIABLE.Draw();
        }
        TurboOutput.PrintBuffer();

        Console.WriteLine("-------------------");
        if (user.TryGetRepository("TinyEngine", out IRepository repository))
        {
            repository.Draw();

            var i = repository.Issues;
            foreach (var VARIABLE in i)
            {
                VARIABLE.Draw();
            }
            
            
            TurboOutput.PrintBuffer();

            // var title = Utility.AskUserForStringInput("Please enter issue title: ");
            // var body = Utility.AskUserForStringInput("Please enter issue body: ");
            // var createdIssue = repository.CreateIssue(title, body, user.UserProfile.login);
            // createdIssue.Draw();
            // TurboOutput.PrintBuffer();

            var id = Utility.AskUserForIntegerInput("Please enter id of issue to edit: ");
            if (repository.TryGetIssue(id, out IIssue issue))
            {
                var newTitle = Utility.AskUserForStringInput("Please enter issue title: ");
                var newBody = Utility.AskUserForStringInput("Please enter issue body: ");

                var updatedIssue = issue.UpdateIssue(newTitle, newBody);
                updatedIssue.Draw();
                TurboOutput.PrintBuffer();
            }
            else
            {
                Console.WriteLine("not found");
            }
        }
        else
        {
            Console.WriteLine("not found");
        }
    }
}