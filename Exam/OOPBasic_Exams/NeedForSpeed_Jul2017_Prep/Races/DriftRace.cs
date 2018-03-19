public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    {
    }

    public override void CalculatePerformancePoints(Car car)
    {
        car.PerformancePoints = car.Suspension + car.Durability;
    }
}