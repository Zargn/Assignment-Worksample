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
        if (Auth.token == null)
        {
            Console.WriteLine("Please add a github personal access token to Auth.cs to use this application.");
            return;
        }
        
        var targetUser = Utility.AskUserForStringInput(@"Welcome to this testing app using my limited github browser system!
Please enter a user you like to inspect!");

        IHttpClient httpClient = new HttpConnection();
        IGithubAPI githubApi = new GithubAPI(httpClient);
        
        var user = githubApi.GetUser(targetUser);
        user.Draw();
        TurboOutput.PrintBuffer();

        var repositories = user.Repositories;
        foreach (var VARIABLE in repositories)
        {
            VARIABLE.Draw();
        }
        TurboOutput.PrintBuffer();
        
        var targetRepository = Utility.AskUserForStringInput("Write repository name to open:");
        
        if (user.TryGetRepository(targetRepository, out IRepository repository))
        {
            repository.Draw();

            var i = repository.Issues;
            foreach (var VARIABLE in i)
            {
                VARIABLE.Draw();
            }
            
            
            TurboOutput.PrintBuffer();

            var userIssueOptions =
                Utility.AskUserForIntegerInput("Do you want to [1] create a issue or [2] edit a issue, in this repo?");
            if (userIssueOptions == 1)
            {
                var newIssue = CreateIssue(repository, user);
                newIssue.Draw();
            }
            else if (userIssueOptions == 2)
            {
                var editedIssue = EditIssue(repository);
                editedIssue.Draw();
            }
            TurboOutput.PrintBuffer();
        }
        else
        {
            Console.WriteLine("not found");
        }
    }

    private IIssue CreateIssue(IRepository currentRepo, IUser currentUser)
    {
        var title = Utility.AskUserForStringInput("Please enter issue title: ");
        var body = Utility.AskUserForStringInput("Please enter issue body: ");
        var createdIssue = currentRepo.CreateIssue(title, body, currentUser.UserProfile.login);
        return createdIssue;
    }

    private IIssue EditIssue(IRepository currentRepo)
    {
        while (true)
        {
            var id = Utility.AskUserForIntegerInput("Please enter id of issue to edit: ");
            if (currentRepo.TryGetIssue(id, out IIssue issue))
            {
                var newTitle = Utility.AskUserForStringInput("Please enter issue title: ");
                var newBody = Utility.AskUserForStringInput("Please enter issue body: ");

                var updatedIssue = issue.UpdateIssue(newTitle, newBody);
                return updatedIssue;
            }
            else
            {
                Console.WriteLine("issue not found, try again!");
            }
        }
    }
}