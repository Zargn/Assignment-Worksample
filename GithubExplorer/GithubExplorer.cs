﻿using ConsoleUtils;
using GithubExplorer.Interfaces;
using GithubExplorer.Networking;

namespace GithubExplorer;

public class Program { public static void Main() { new GithubExplorer().Run(); } }

public class GithubExplorer
{
    public void Run()
    {
        var targetUser = Utility.AskUserForStringInput(@"Welcome to this very limited github browser!
Please enter a user you like to inspect!");

        IHttpClient httpClient = new HttpConnection();
        IGithubAPI githubApi = new GithubAPI(httpClient);
        
        var user = githubApi.GetUser(targetUser);
        user.Draw();

        var targetRepository = Utility.AskUserForStringInput("Write repository name to open:");

        var repository = user.GetRepository(targetRepository);
        repository.Draw();
    }
}