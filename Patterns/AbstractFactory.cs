using SmartBuilding.Models;

namespace SmartBuilding.Patterns;

public interface IFloorDeviceFactory
{
    ISensor CreateSensor(SensorKind kind);
    IIndicator CreateIndicator();
    IRecorder CreateRecorder();
}

public class BasicFloorFactory : IFloorDeviceFactory
{
    public ISensor CreateSensor(SensorKind kind) => new BasicSensor(kind);
    public IIndicator CreateIndicator() => new BasicIndicator();
    public IRecorder CreateRecorder() => new BasicRecorder();
}

public class PremiumFloorFactory : IFloorDeviceFactory
{
    public ISensor CreateSensor(SensorKind kind) => new PremiumSensor(kind);
    public IIndicator CreateIndicator() => new PremiumIndicator();
    public IRecorder CreateRecorder() => new PremiumRecorder();
}
