namespace Tiny_Browser.Networking;

public class Http11Request
{
    public const string EndOfHttpRequest = "\n\n";
    public string Method;
    public string Path;
    public Dictionary<string, string> Headers = new();

    public Http11Request(string method, string path, string hostName)
    {
        Method = method;
        Path = path;
        Headers["Connection"] = "Keep-Alive";
        Headers["Host"] = hostName;
    }

    public override string ToString()
    {
        return
            $"{Method} {Path} HTTP/1.1\n{string.Join("\n", Headers.Select(pair => $"{pair.Key}: {pair.Value}"))}{EndOfHttpRequest}";
    }
}