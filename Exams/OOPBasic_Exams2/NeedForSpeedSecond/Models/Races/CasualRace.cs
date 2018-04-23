public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    {
    }

    protected override void CalculatePerformancePoints(Car car)
    {
        car.GetOverallPerformance();
    }
}