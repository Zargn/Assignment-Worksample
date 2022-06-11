using ConsoleUtils;
using LameScooter.Interfaces;
using LameScooter.Serialization;

public class Program
{
    static async Task Main(string[] args)
    {
        ILameScooterRental scooterRental = new LocalLameScooterRental(new JsonDeserializer());
        
        var stationName = Utility.AskUserForStringInput("Please enter station name to get statistics from: ");
        var amount = await scooterRental.GetAvailableScootersAtStation(stationName);
        Console.WriteLine(amount);
        if (await scooterRental.TryGetStation(stationName, out IStationModel stationModel))
        {
            Console.WriteLine(stationModel);
        }
        else
        {
            Console.WriteLine("Station not found!");
        }
    }
}