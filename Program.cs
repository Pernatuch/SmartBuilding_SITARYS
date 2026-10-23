using SmartBuilding.Models;
using SmartBuilding.Patterns;

namespace SmartBuilding;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== СИСТЕМА МОНИТОРИНГА ЗДАНИЯ ===\n");

        Console.WriteLine("=== 1. Abstract Factory: создание комплектов устройств ===");
        var floor1 = new Floor(1, new BasicFloorFactory());
        var floor2 = new Floor(2, new PremiumFloorFactory());
        Console.WriteLine("Этаж 1: создан базовый комплект устройств.");
        Console.WriteLine("Этаж 2: создан премиальный комплект устройств.\n");

        Console.WriteLine("=== 2. Observer: подписчики ===");
        var panel = new ControlPanel();
        var archive = new Archive();

        Console.WriteLine("=== 3. Strategy: правила тревоги ===");
        var alarm = new AlarmSystem(new IAlarmStrategy[]
        {
            new TemperatureAlarmStrategy(),
            new SmokeAlarmStrategy(),
            new MotionAlarmStrategy()
        });
        Console.WriteLine("Настроены стратегии температуры, дыма и движения.\n");

        foreach (var floor in new[] { floor1, floor2 })
        {
            floor.Subscribe(panel);
            floor.Subscribe(archive);
            floor.Subscribe(alarm);
        }

        Console.WriteLine("\n=== 4. Опрос датчиков первого этажа ===");
        floor1.PollSensors();

        Console.WriteLine("\n=== 5. Опрос датчиков второго этажа ===");
        floor2.PollSensors();

        Console.WriteLine("\n=== 6. Демонстрация отписки от уведомлений ===");
        floor1.Unsubscribe(archive);

        Console.WriteLine("\n=== 7. Повторный опрос первого этажа ===");
        floor1.PollSensors();

        Console.WriteLine("\nДемонстрация завершена. Нажмите Enter для выхода.");
        Console.ReadLine();
    }
}
