public class EnduranceDriver : Driver
{
    private const double EnduranceFuelConsumptionPerKm = 1.5;

    public EnduranceDriver(string name, Car car)
        : base(name, car, EnduranceFuelConsumptionPerKm)
    {
    }
}