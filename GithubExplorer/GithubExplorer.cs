using ConsoleUtils;

namespace GithubExplorer;

public class Program { public static void Main() { new GithubExplorer().Run(); } }

public class GithubExplorer
{
    public void Run()
    {
        var targetUser = Utility.AskUserForStringInput(@"Welcome to this very limited github browser!
Please enter a user you like to inspect!");

        Console.WriteLine(targetUser);
    }
}