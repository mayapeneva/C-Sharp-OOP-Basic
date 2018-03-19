public class AggressiveDriver : Driver
{
    private const double AggressiveFuelConsumptionPerKm = 2.7;

    public AggressiveDriver(string name, Car car)
        : base(name, car, AggressiveFuelConsumptionPerKm)
    {
    }

    public override double Speed => base.Speed * 1.3;
}