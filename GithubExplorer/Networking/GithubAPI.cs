using GithubExplorer.Interfaces;

namespace GithubExplorer.Networking;



public class GithubAPI : IGithubAPI
{
    private static readonly HttpClient httpClient = new();
    public IUser GetUser(string userName)
    {
        throw new NotImplementedException();
    }
}