using System.Text.Json;
using ConsoleUtils;
using GithubExplorer.GithubObjects;
using GithubExplorer.Interfaces;

namespace GithubExplorer.Networking;



public class GithubAPI : IGithubAPI
{
    public GithubAPI(IHttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    private IHttpClient httpClient;

    public IUser GetUser(string userName)
    {
        var response = httpClient.SendRequest(new HttpRequestMessage(HttpMethod.Get, $"users/{userName}"));
        var userProfile = response.Deserialize<UserProfile>();
        return new User(httpClient, userProfile);
    }
}