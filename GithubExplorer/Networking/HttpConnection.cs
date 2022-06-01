using GithubExplorer.Interfaces;

namespace GithubExplorer.Networking;

public class HttpConnection : IHttpClient
{
    // HttpClient is intended to be instantiated once per application, rather than per-use. See microsoft docs.
    static readonly HttpClient httpClient = new();

    public HttpConnection()
    {
        httpClient.BaseAddress = new Uri("https://api.github.com");
    }

    public HttpResponseMessage SendRequest(HttpRequestMessage httpRequestMessage)
    {
        var response = httpClient.Send(httpRequestMessage);
        return response;
    }

    public void Dispose()
    {
        httpClient.Dispose();
    }

    public void AddDefaultHeaders(string header, string value)
    {
        httpClient.DefaultRequestHeaders.Add(header, value);
    }

    public void RemoveDefaultHeaders(string header)
    {
        httpClient.DefaultRequestHeaders.Remove(header);
    }
}