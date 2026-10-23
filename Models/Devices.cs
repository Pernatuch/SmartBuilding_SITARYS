namespace SmartBuilding.Models;

public interface ISensor
{
    SensorKind Kind { get; }
    Reading Read(int floorNumber);
}

public interface IIndicator
{
    void Show(Reading reading);
}

public interface IRecorder
{
    void Record(Reading reading);
}

public class BasicSensor : ISensor
{
    private readonly Random _random = new();
    public SensorKind Kind { get; }

    public BasicSensor(SensorKind kind) => Kind = kind;

    public Reading Read(int floorNumber)
    {
        double value = Kind switch
        {
            SensorKind.Temperature => 20 + _random.NextDouble() * 25,
            SensorKind.Motion => _random.Next(0, 2),
            SensorKind.Smoke => _random.NextDouble() * 100,
            _ => 0
        };

        return new Reading(floorNumber, Kind, Math.Round(value, 1), DateTime.Now);
    }
}

public class PremiumSensor : ISensor
{
    private readonly Random _random = new();
    public SensorKind Kind { get; }

    public PremiumSensor(SensorKind kind) => Kind = kind;

    public Reading Read(int floorNumber)
    {
        double value = Kind switch
        {
            SensorKind.Temperature => 20 + _random.NextDouble() * 40,
            SensorKind.Motion => _random.Next(0, 2),
            SensorKind.Smoke => _random.NextDouble() * 150,
            _ => 0
        };

        return new Reading(floorNumber, Kind, Math.Round(value, 1), DateTime.Now);
    }
}

public class BasicIndicator : IIndicator
{
    public void Show(Reading reading) =>
        Console.WriteLine($"[Базовый индикатор] Этаж {reading.FloorNumber}: {reading.Kind} = {reading.Value}");
}

public class PremiumIndicator : IIndicator
{
    public void Show(Reading reading) =>
        Console.WriteLine($"[Премиум-индикатор] Этаж {reading.FloorNumber}: {reading.Kind} = {reading.Value}");
}

public class BasicRecorder : IRecorder
{
    public void Record(Reading reading) =>
        Console.WriteLine($"[Базовый регистратор] Запись сохранена: {reading.Kind} = {reading.Value}");
}

public class PremiumRecorder : IRecorder
{
    public void Record(Reading reading) =>
        Console.WriteLine($"[Премиум-регистратор] Запись сохранена: {reading.Kind} = {reading.Value}");
}
