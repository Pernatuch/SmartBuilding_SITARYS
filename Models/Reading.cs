namespace SmartBuilding.Models;

public enum SensorKind
{
    Temperature,
    Motion,
    Smoke
}

public record Reading(
    int FloorNumber,
    SensorKind Kind,
    double Value,
    DateTime Time);
