namespace LameScooter.Interfaces;

public interface ILameScooterRental
{
    Task<int> GetAvailableScootersAtStation(string stationName);
    Task<IStationModel> TryGetStation(string stationName);
}