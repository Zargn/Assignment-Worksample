namespace GithubExplorer.Interfaces;



public interface IGithubAPI
{
    /// <summary>
    /// Try to get the github user with the provided username
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public IUser GetUser(string userName);
}

public interface IUser : IDisplayable
{
    /// <summary>
    /// Get all user repositories.
    /// </summary>
    public IEnumerable<IRepository> Repositories { get; }
    
    /// <summary>
    /// Get user profile information.
    /// </summary>
    public IUserProfile UserProfile { get; }

    /// <summary>
    /// Try getting a repository with the provided name from this user.
    /// </summary>
    /// <param name="repositoryName"></param>
    /// <param name="repository"></param>
    /// <returns></returns>
    public bool TryGetRepository(string repositoryName, out IRepository repository);
}

public interface IUserProfile
{
    public string name { get; }
    public string location { get; }
    public string login { get; }
}

public interface IUserReference
{
    public string login { get; }
    public int id { get; }
}


public interface IRepository : IDisplayable
{
    public IRepositoryData RepositoryData { get; }
    
    
    
    /// <summary>
    /// Contains all issues attached to this repository.
    /// </summary>
    public IEnumerable<IIssue> Issues { get; }

    /// <summary>
    /// Try getting a issue by name.
    /// </summary>
    /// <param name="issueId"></param>
    /// <param name="issue"></param>
    /// <returns></returns>
    public IIssue TryGetIssue(int issueId, out IIssue issue);
}

public interface IRepositoryData
{
    public string name { get; }
    public string description { get; }
    public string issues_url { get; }
}

public interface IIssue : IDisplayable
{
    public IIssueData IssueData { get; }
    public IRepository Repository { get; }
    public IEnumerable<IComment> Comments { get; }
    public void Close();
    public void CreateComment();
}

public interface IIssueData
{
    public string title { get; }
    public string state { get; }
    public string body { get; }
    public int number { get; }
}

public interface IComment : IDisplayable
{
    public void Edit();
    public void Delete();
}

public interface ICommentData
{
    public int id { get; }
    public string body { get; }
}