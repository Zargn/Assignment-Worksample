using GithubExplorer.Interfaces;

namespace GithubExplorer.GithubObjects;

public class Repository : IRepository
{
    public string name { get; init; }
    public string description { get; init; }

    public void Draw()
    {
        Console.WriteLine(this);
    }
}