using System.Net.Http.Json;
using ConsoleUtils;
using ExtraExtensionMethods;
using GithubExplorer.Interfaces;

namespace GithubExplorer.GithubObjects;

public record Repository : IRepository
{
    public IRepositoryData RepositoryData { get; }

    public IEnumerable<IIssue> Issues
    {
        // get;
        get
        {
            var response = httpClient.SendRequest(new HttpRequestMessage(HttpMethod.Get, RepositoryData.issues_url.Replace("{/number}", "")));
            var issueDatas = response.Deserialize<IssueData[]>();
            foreach (var issueData in issueDatas)
            {
                yield return new Issue(issueData, httpClient);
            }
        }
    }

    private IHttpClient httpClient;

    public Repository(IRepositoryData repositoryData, IHttpClient httpClient)
    {
        this.httpClient = httpClient;
        RepositoryData = repositoryData;
    }
    
    public bool TryGetIssue(int issueId, out IIssue issue)
    {
        var response = httpClient.SendRequest(new HttpRequestMessage(HttpMethod.Get, RepositoryData.issues_url.Replace("{/number}", $"/{issueId}")));
        Console.WriteLine(response);
        issue = new Issue(response.Deserialize<IssueData>(), httpClient);
        return issue.IssueData.url != null;
    }

    public IIssue CreateIssue(string title, string body, string owner)
    {
        var issueRequest = new HttpRequestMessage(HttpMethod.Post, RepositoryData.issues_url.Replace("{/number}", ""));
        issueRequest.Content = JsonContent.Create(new {title, body});

        var response = httpClient.SendRequest(issueRequest);

        var issueData = response.Deserialize<IssueData>();
        return new Issue(issueData, httpClient);
    }

    public void Draw()
    {
        TurboOutput.WriteLineToBuffer(RepositoryData);
    }
}

public record RepositoryData : IRepositoryData
{
    public string name { get; init; }
    public string description { get; init; }
    public string issues_url { get; init; }
}