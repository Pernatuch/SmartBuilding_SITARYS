using SmartBuilding.Models;

namespace SmartBuilding.Patterns;

public interface IAlarmStrategy
{
    bool ShouldTrigger(Reading reading);
}

public class TemperatureAlarmStrategy : IAlarmStrategy
{
    public bool ShouldTrigger(Reading reading) =>
        reading.Kind == SensorKind.Temperature && reading.Value > 35;
}

public class SmokeAlarmStrategy : IAlarmStrategy
{
    public bool ShouldTrigger(Reading reading) =>
        reading.Kind == SensorKind.Smoke && reading.Value > 50;
}

public class MotionAlarmStrategy : IAlarmStrategy
{
    public bool ShouldTrigger(Reading reading) =>
        reading.Kind == SensorKind.Motion && reading.Value >= 1;
}

public class AlarmSystem : ISubscriber
{
    private readonly List<IAlarmStrategy> _strategies;

    public AlarmSystem(IEnumerable<IAlarmStrategy> strategies)
    {
        _strategies = strategies.ToList();
    }

    public void Update(Reading reading)
    {
        foreach (var strategy in _strategies)
        {
            if (strategy.ShouldTrigger(reading))
            {
                Console.WriteLine($"!!! ТРЕВОГА !!! Этаж {reading.FloorNumber}, датчик {reading.Kind}, значение {reading.Value}");
                return;
            }
        }

        Console.WriteLine($"[Система тревоги] Опасности по показанию {reading.Kind} не обнаружено.");
    }
}
