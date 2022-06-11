namespace LameScooter.Interfaces;

public interface IJsonSerializer
{
    public T DeSerialize<T>(string json);
}