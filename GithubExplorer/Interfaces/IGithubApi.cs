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
    /// Try getting the a repository with the provided name from this user.
    /// </summary>
    /// <param name="repositoryName"></param>
    /// <returns></returns>
    public IRepository GetRepository(string repositoryName);
    
    public string name { get; init; }
    public string location { get; init; }
}

public interface IRepository : IDisplayable
{
    public string name { get; init; }
    public string description { get; init; }
}