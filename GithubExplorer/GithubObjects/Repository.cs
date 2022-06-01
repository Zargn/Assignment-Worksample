using GithubExplorer.Interfaces;

namespace GithubExplorer.GithubObjects;

public class Repository : IRepository
{
    public string Name { get; }
    public string Description { get; }
    
    public void Draw()
    {
        throw new NotImplementedException();
    }
}