namespace LameScooter.Interfaces;

public interface IStationModel
{
    public string id { get; }
    public string name { get; }
    public int x { get; }
    public int y { get; }
    public int bikesAvailable { get; }
    public int spacesAvailable { get; }
    public int capacity { get; }
    public bool allowDropoff { get; }
    public bool allowOverloading { get; }
    public bool isFloatingBike { get; }
    public bool isCarStation { get; }
    public string state { get; }
    public string[] networks { get; }
    public bool realTimeData { get; }
}