public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    {
    }

    public override void CalculatePerformancePoints(Car car)
    {
        car.PerformancePoints = (car.Horsepower / car.Acceleration) + (car.Suspension + car.Durability);
    }
}