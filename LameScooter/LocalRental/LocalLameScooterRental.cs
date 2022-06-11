using LameScooter.Data;
using LameScooter.Interfaces;

public class LocalLameScooterRental : ILameScooterRental
{
    public LocalLameScooterRental(IJsonSerializer jsonSerializer, IFileReader fileReader)
    {
        this.jsonSerializer = jsonSerializer;
        this.fileReader = fileReader;

        // I am not sure if this will actually run async, or if it will run to end and then exit the constructor.
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
        foreach (var stationModel in jsonSerializer.DeSerialize<StationModel[]>(json))
        {
            stationNameLookup.Add(stationModel.name, stationModel);
        }
    }
    
    
    

    public Task<int> GetAvailableScootersAtStation(string stationName)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TryGetStation(string stationName, out IStationModel stationModel)
    {
        throw new NotImplementedException();
    }
}