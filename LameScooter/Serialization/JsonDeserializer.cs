using System.Text.Json;
using LameScooter.Interfaces;

namespace LameScooter.Serialization;

public class JsonDeserializer : IJsonSerializer
{
    public T DeSerialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json);
    }
}