using GithubExplorer.Interfaces;

namespace GithubExplorer.GithubObjects;


public record User : IUser
{
    public IEnumerable<IRepository> Repositories
    {
        get
        {
            var response = httpClient.SendRequest(new HttpRequestMessage(HttpMethod.Get, $"users/{UserProfile.login}/repos"));
            return response.Deserialize<Repository[]>();
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
        repository = response.Deserialize<Repository>();
        return repository.name != null;
    }
    
    public void Draw()
    {
        Console.WriteLine(UserProfile);
    }
}


public record UserProfile : IUserProfile
{
    public string name { get; init; }
    public string location { get; init; }
    public string login { get; init; }
}