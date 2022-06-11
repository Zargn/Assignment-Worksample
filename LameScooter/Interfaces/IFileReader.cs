namespace LameScooter.Interfaces;

public interface IFileReader
{
    public Task<string> ReadFileAsync();
}