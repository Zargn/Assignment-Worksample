using LameScooter.Interfaces;

namespace LameScooter.LocalRental;

public class FileReader : IFileReader
{
    public async Task<string> ReadFileAsync(string filePath)
    {
        var fileStream = new FileStream(filePath, FileMode.Open);
        var streamReader = new StreamReader(fileStream);
        
        return await streamReader.ReadToEndAsync();
    }
}