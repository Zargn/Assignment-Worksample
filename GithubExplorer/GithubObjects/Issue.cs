using ConsoleUtils;
using GithubExplorer.Interfaces;

namespace GithubExplorer.GithubObjects;

public record Issue : IIssue
{
    public Issue(IIssueData issueData, IHttpClient httpClient)
    {
        IssueData = issueData;
    }
    
    public void Draw()
    {
        TurboOutput.WriteLineToBuffer(IssueData);
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
}

public record IssueData : IIssueData
{
    public string title { get; init; }
    public string state { get; init; }
    public string body { get; init; }
    public int number { get; init; }
}