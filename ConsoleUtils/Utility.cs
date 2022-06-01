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
}