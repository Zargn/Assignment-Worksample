namespace GithubExplorer.Interfaces;



public interface IHttpClient
{
    public HttpResponseMessage SendRequest(HttpRequestMessage httpRequestMessage);

    public void Dispose();

    public void AddDefaultHeaders(string header, string value);

    public void RemoveDefaultHeaders(string header);
}