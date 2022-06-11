namespace LameScooter.Interfaces;

public interface ILameScooterRental
{
    Task<int> GetAvailableScootersAtStation(string stationName);
    Task<bool> TryGetStation(string stationName, out IStationModel stationModel);
}