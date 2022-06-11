using ConsoleUtils;
using LameScooter.Interfaces;

public class Program
{
    static async Task Main(string[] args)
    {
        ILameScooterRental scooterRental = null;

        while (true)
        {
            var stationName = Utility.AskUserForStringInput("Please enter station name to get statistics from: ");
            var amount = await scooterRental.GetScooterAmount(stationName);
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
}