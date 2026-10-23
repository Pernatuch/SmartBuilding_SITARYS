using SmartBuilding.Patterns;

namespace SmartBuilding.Models;

public class Floor
{
    private readonly List<ISensor> _sensors = new();
    private readonly IIndicator _indicator;
    private readonly IRecorder _recorder;
    private readonly List<ISubscriber> _subscribers = new();

    public int Number { get; }

    public Floor(int number, IFloorDeviceFactory factory)
    {
        Number = number;
        _sensors.Add(factory.CreateSensor(SensorKind.Temperature));
        _sensors.Add(factory.CreateSensor(SensorKind.Motion));
        _sensors.Add(factory.CreateSensor(SensorKind.Smoke));
        _indicator = factory.CreateIndicator();
        _recorder = factory.CreateRecorder();
    }

    public void Subscribe(ISubscriber subscriber)
    {
        if (_subscribers.Contains(subscriber))
            return;

        _subscribers.Add(subscriber);
        Console.WriteLine($"[Observer] Подписчик {subscriber.GetType().Name} добавлен на этаж {Number}.");
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        if (_subscribers.Remove(subscriber))
            Console.WriteLine($"[Observer] Подписчик {subscriber.GetType().Name} удалён с этажа {Number}.");
    }

    public void PollSensors()
    {
        foreach (var sensor in _sensors)
        {
            Reading reading = sensor.Read(Number);
            _indicator.Show(reading);
            _recorder.Record(reading);

            Console.WriteLine("[Observer] Рассылка показания подписчикам.");
            foreach (var subscriber in _subscribers.ToArray())
                subscriber.Update(reading);
        }
    }
}
