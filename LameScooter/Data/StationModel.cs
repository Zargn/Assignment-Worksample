using LameScooter.Interfaces;

namespace LameScooter.Data;

public record StationModel : IStationModel
{
    public string id { get; init; }
    public string name { get; init; }
    public float x { get; init; }
    public float y { get; init; }
    public int bikesAvailable { get; init; }
    public int spacesAvailable { get; init; }
    public int capacity { get; init; }
    public bool allowDropoff { get; init; }
    public bool allowOverloading { get; init; }
    public bool isFloatingBike { get; init; }
    public bool isCarStation { get; init; }
    public string state { get; init; }
    public string[] networks { get; init; }
    public bool realTimeData { get; init; }
}

public record StationList
{
    public StationModel[] stations { get; init; }
}