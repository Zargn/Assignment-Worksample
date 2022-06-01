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
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"users/{userName}");
        var response = httpClient.SendRequest(request);
        Console.WriteLine(response);
        throw new NotImplementedException();
    }
}