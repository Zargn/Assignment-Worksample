using System.Net.Http.Json;
using ConsoleUtils;
using ExtraExtensionMethods;
using GithubExplorer.Interfaces;

namespace GithubExplorer.GithubObjects;

public record Issue : IIssue
{
    public Issue(IIssueData issueData, IHttpClient httpClient)
    {
        IssueData = issueData;
        this.httpClient = httpClient;
    }
    
    private IHttpClient httpClient;


    public void Draw()
    {
        TurboOutput.WriteLineToBuffer(@$"
########################################################################################################################
Issue: {IssueData.title} [{IssueData.number}]
State: {IssueData.state}

Issue body:
{IssueData.body}
");
    }

    public IIssueData IssueData { get; }
    public IRepository Repository { get; }
    public IEnumerable<IComment> Comments { get; }
    public void Close()
    {
        throw new NotImplementedException();
    }

    public void CreateComment()
    {
        throw new NotImplementedException();
    }

    public IIssue UpdateIssue(string title, string body)
    {
        var issueRequest = new HttpRequestMessage(HttpMethod.Patch, IssueData.url);
        issueRequest.Content = JsonContent.Create(new {title, body});

        var response = httpClient.SendRequest(issueRequest);

        var issueData = response.Deserialize<IssueData>();
        return new Issue(issueData, httpClient);
    }
}

public record IssueData : IIssueData
{
    public string title { get; init; }
    public string state { get; init; }
    public string body { get; init; }
    public int number { get; init; }
    public string url { get; init; }
}