using ConsoleUtils;
using GithubExplorer.Interfaces;

namespace GithubExplorer.GithubObjects;


public record User : IUser
{
    public IEnumerable<IRepository> Repositories
    {
        get
        {
            var response = httpClient.SendRequest(new HttpRequestMessage(HttpMethod.Get, $"users/{UserProfile.login}/repos"));
            var repositoryDataArray = response.Deserialize<RepositoryData[]>();
            foreach (var repositoryData in repositoryDataArray)
            {
                yield return new Repository(repositoryData, httpClient);
            }
        }
    }
    
    public IUserProfile UserProfile { get; }
    
    private IHttpClient httpClient;

    
    
    public User(IHttpClient httpClient, IUserProfile userProfile)
    {
        this.httpClient = httpClient;
        UserProfile = userProfile;
    }
    
    
    
    public bool TryGetRepository(string repositoryName, out IRepository repository)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"repos/{UserProfile.login}/{repositoryName}");
        var response = httpClient.SendRequest(request);
        var repositoryData = response.Deserialize<RepositoryData>();
        repository = new Repository(repositoryData, httpClient);
        return repository.RepositoryData.name != null;

    }
    
    public void Draw()
    {
        TurboOutput.WriteLineToBuffer(UserProfile);
    }
}


public record UserProfile : IUserProfile
{
    public string name { get; init; }
    public string location { get; init; }
    public string login { get; init; }
}

public record UserReference : IUserReference
{
    public string login { get; init; }
    public int id { get; init; }
}