using GithubExplorer.Interfaces;

namespace GithubExplorer.GithubObjects;

public class User : IUser
{
    public IRepository GetRepository(string repositoryName)
    {
        throw new NotImplementedException();
    }

    public string Name { get; }
    public string Location { get; }
    public void Draw()
    {
        throw new NotImplementedException();
    }
}