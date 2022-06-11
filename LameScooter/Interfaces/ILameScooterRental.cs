namespace LameScooter.Interfaces;

public interface ILameScooterRental
{
    Task<int> GetScooterAmount(string stationName);
    Task<bool> TryGetStation(string stationName, out IStationModel stationModel);
}