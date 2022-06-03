using GithubExplorer.Interfaces;

namespace GithubExplorer.GithubObjects;

public record Repository : IRepository
{
    public IRepositoryData RepositoryData { get; }

    public IEnumerable<IIssue> Issues
    {
        get;
        // get
        // {
        //     var response = httpClient.SendRequest(new HttpRequestMessage(HttpMethod.Get, $"repos/{RepositoryData.login}/{RepositoryData.name}/issues"));
        //     return response.Deserialize<I[]>();
        // }
    }

    private IHttpClient httpClient;

    public Repository(IRepositoryData repositoryData, IHttpClient httpClient)
    {
        this.httpClient = httpClient;
        RepositoryData = repositoryData;
    }
    
    public IIssue TryGetIssue(int issueId, out IIssue issue)
    {
        throw new NotImplementedException();
    }
    
    public void Draw()
    {
        Console.WriteLine(RepositoryData);
    }
}

public record RepositoryData : IRepositoryData
{
    public string name { get; init; }
    public string description { get; init; }
    public IUserReference owner { get; init; }
}