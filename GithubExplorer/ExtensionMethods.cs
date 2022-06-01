using System.Text.Json;



namespace GithubExplorer;

public static class ExtensionMethods
{
    public static T Deserialize<T>(this HttpResponseMessage httpResponseMessage)
    {
        var json = new StreamReader(httpResponseMessage.Content.ReadAsStream()).ReadToEnd();
        return JsonSerializer.Deserialize<T>(json);
    }
}