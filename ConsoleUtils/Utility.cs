using System.Text;

namespace ConsoleUtils;

public class Utility
{
    public static string AskUserForStringInput(string question)
    {
        Console.WriteLine(question);
        return Console.ReadLine();
    }

    public static int AskUserForIntegerInput(string question)
    {
        while (true)
        {
            try
            {
                var inputString = AskUserForStringInput(question);
                var inputInteger = Int32.Parse(inputString);
                return inputInteger;
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect format! Only numbers are allowed. Please try again.");
            }
        }
    }


    private static StringBuilder sb = new();
    
    public static void WriteLineToConsoleBuffer(string s)
    {
        sb.AppendLine(s);
    }
    
    public static void WriteLineToConsoleBuffer(object obj)
    {
        WriteLineToConsoleBuffer(obj.ToString());
    }

    public static void WriteToConsoleBuffer(string s)
    {
        sb.Append(s);
    }
    
    public static void WriteToConsoleBuffer(object obj)
    {
        WriteToConsoleBuffer(obj.ToString());
    }

    public static void PrintConsoleBuffer()
    {
        Console.WriteLine(sb);
        sb.Clear();
    }
}