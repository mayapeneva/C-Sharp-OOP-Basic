public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool)
        : base(length, route, prizePool)
    {
    }

    protected override void CalculatePerformancePoints(Car car)
    {
        car.GetEnginePerformance(); ;
    }
}