using ConsoleUtils;
using LameScooter.Interfaces;
using LameScooter.LocalRental;
using LameScooter.Serialization;

public class Program
{
    static async Task Main(string[] args)
    {
        ILameScooterRental scooterRental = new LocalLameScooterRental(new JsonDeserializer(), new FileReader());
        
        var stationName = Utility.AskUserForStringInput("Please enter station name to get statistics from: ");
        var amount = await scooterRental.GetAvailableScootersAtStation(stationName);
        Console.WriteLine(amount);
        Console.WriteLine(await scooterRental.TryGetStation(stationName));
    }
}