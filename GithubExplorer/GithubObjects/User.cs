using System.Text.Json;
using GithubExplorer.Interfaces;
using GithubExplorer.Networking;

namespace GithubExplorer.GithubObjects;


public record User : IUser
{
    public string name { get; init; }
    public string location { get; init; }
    public string login { get; init; }

    public static IHttpClient httpClient = new HttpConnection();
    
    // public User(IHttpClient httpClient)
    // {
    //     this.httpClient = httpClient;
    // }
    
    public IRepository[] GetAllPublicRepositories()
    {
        var response = httpClient.SendRequest(new HttpRequestMessage(HttpMethod.Get, $"users/{login}/repos"));

        return response.Deserialize<Repository[]>();
    }

    
    public IRepository GetRepository(string repositoryName)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"users/{login}/repos");
        var response = httpClient.SendRequest(request);

        Console.WriteLine(response);
        
        var json = new StreamReader(response.Content.ReadAsStream()).ReadToEnd();

        Console.WriteLine(json);

        // var user = JsonSerializer.Deserialize<User>(json, serializeAllFields);

        // return user;
        
        throw new NotImplementedException();
    }

    public void Draw()
    {
        Console.WriteLine(this);
    }
}