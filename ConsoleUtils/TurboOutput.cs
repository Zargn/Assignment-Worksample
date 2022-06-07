using System.Text;

namespace ConsoleUtils;

public static class TurboOutput
{
    private static StringBuilder sb = new();
    
    public static void WriteLineToBuffer(string s)
    {
        sb.AppendLine(s);
    }
    
    public static void WriteLineToBuffer(object obj)
    {
        WriteLineToBuffer(obj.ToString());
    }

    public static void WriteToBuffer(string s)
    {
        sb.Append(s);
    }
    
    public static void WriteToBuffer(object obj)
    {
        WriteToBuffer(obj.ToString());
    }

    public static void PrintBuffer()
    {
        Console.WriteLine(sb);
        sb.Clear();
    }
}