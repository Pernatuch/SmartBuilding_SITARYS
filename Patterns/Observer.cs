using SmartBuilding.Models;

namespace SmartBuilding.Patterns;

public interface ISubscriber
{
    void Update(Reading reading);
}

public class ControlPanel : ISubscriber
{
    public void Update(Reading reading) =>
        Console.WriteLine($"[Панель управления] Получено: {reading.Kind} = {reading.Value}, этаж {reading.FloorNumber}");
}

public class Archive : ISubscriber
{
    public void Update(Reading reading) =>
        Console.WriteLine($"[Архив] Показание {reading.Kind} добавлено в историю: {reading.Value}");
}
