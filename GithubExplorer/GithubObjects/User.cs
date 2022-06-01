using GithubExplorer.Interfaces;

namespace GithubExplorer.GithubObjects;



public record User : IUser
{
    public IRepository GetRepository(string repositoryName)
    {
        throw new NotImplementedException();
    }

    public string name { get; init; }
    public string location { get; init; }
    

    public void Draw()
    {
        Console.WriteLine(this);
    }
}