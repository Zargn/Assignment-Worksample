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
    
    // /// <summary>
    // /// Get all public repositories owned by this user.
    // /// </summary>
    // /// <returns></returns>
    // public IRepository[] GetAllPublicRepositories();
}

public interface IUserProfile
{
    public string name { get; init; }
    public string location { get; init; }
    public string login { get; init; }
}


public interface IRepository : IDisplayable
{
    public string name { get; init; }
    public string description { get; init; }

    /// <summary>
    /// Try getting a issue by name.
    /// </summary>
    /// <param name="issueId"></param>
    /// <returns></returns>
    public IIssue GetIssues(int issueId);

    /// <summary>
    /// Get all issues in this repository.
    /// </summary>
    /// <returns></returns>
    public IIssue[] GetAllIssues();
}

public interface IIssue : IDisplayable
{
    public string title { get; init; }
    public string state { get; init; }
    public string body { get; init; }
    public int number { get; init; }
}