using System.Text.Json;
using GithubExplorer.Interfaces;
using GithubExplorer.Networking;

namespace GithubExplorer.GithubObjects;


public record User : IUser
{
    public string name { get; init; }
    public string location { get; init; }
    public string login { get; init; }
    
    private IHttpClient httpClient;

    public void SetHttpClient(IHttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public IRepository[] GetAllPublicRepositories()
    {
        var response = httpClient.SendRequest(new HttpRequestMessage(HttpMethod.Get, $"users/{login}/repos"));

        return response.Deserialize<Repository[]>();
    }

    
    public IRepository GetRepository(string repositoryName)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"repos/{login}/{repositoryName}");
        var response = httpClient.SendRequest(request);
        return response.Deserialize<Repository>();
    }

    public void Draw()
    {
        Console.WriteLine(this);
    }
}