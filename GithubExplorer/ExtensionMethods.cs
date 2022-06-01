using System.Text.Json;
using GithubExplorer.GithubObjects;

namespace GithubExplorer;

public static class ExtensionMethods
{
    public static T Deserialize<T>(this HttpResponseMessage httpResponseMessage)
    {
        var json = new StreamReader(httpResponseMessage.Content.ReadAsStream()).ReadToEnd();
        var result = JsonSerializer.Deserialize<T>(json);
        return result;
    }
}