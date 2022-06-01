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
    private readonly JsonSerializerOptions serializeAllFields = new() {IncludeFields = true};
    
    public IUser GetUser(string userName)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"users/{userName}");
        var response = httpClient.SendRequest(request);

        var json = new StreamReader(response.Content.ReadAsStream()).ReadToEnd();

        var user = JsonSerializer.Deserialize<User>(json, serializeAllFields);

        return user;
    }
}