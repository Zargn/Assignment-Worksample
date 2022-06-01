using System.Text.Json;
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
        var user = response.Deserialize<User>();
        user.SetHttpClient(httpClient);
        return user;
    }
}