using LameScooter.Data;
using LameScooter.Interfaces;

public class LocalLameScooterRental : ILameScooterRental
{
    public LocalLameScooterRental(IJsonSerializer jsonSerializer, IFileReader fileReader)
    {
        this.jsonSerializer = jsonSerializer;
        this.fileReader = fileReader;

        // I am not sure if this will actually run async, or if it will run to end and then exit the constructor.
        // loadStationsTask = LoadStations();
        loadStationsTask = LoadStations();
    }

    private IJsonSerializer jsonSerializer;
    private IFileReader fileReader;

    // The idea behind this was to await this task in the two interface methods, allowing us to load the file in the 
    // background, and if not done, then make the station methods wait until it is ready.
    private Task loadStationsTask;
    
    private Dictionary<string, IStationModel> stationNameLookup = new();

    
    private async Task LoadStations()
    {
        var json = await fileReader.ReadFileAsync("Scooters.json");
        var stationModels = jsonSerializer.DeSerialize<StationList>(json);
        foreach (var stationModel in stationModels.stations)
        {
            stationNameLookup.Add(stationModel.name, stationModel);
        }
    }
    
    
    
    public async Task<int> GetAvailableScootersAtStation(string stationName)
    {
        try
        {
            return stationNameLookup[stationName].bikesAvailable;
        }
        catch (KeyNotFoundException)
        {
            return -1;
        }
    }

    public async Task<IStationModel> TryGetStation(string stationName)
    {
        try
        {
            return stationNameLookup[stationName];
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }
}