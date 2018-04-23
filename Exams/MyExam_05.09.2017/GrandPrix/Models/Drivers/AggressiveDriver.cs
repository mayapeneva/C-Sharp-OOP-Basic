public class AggressiveDriver : Driver
{
    private const double FuelConsumptionPerKmConst = 2.7;
    private const double SpecialOvertakeTime = 0.03;

    public AggressiveDriver(string name, Car car)
        : base(name, car, FuelConsumptionPerKmConst)
    {
    }

    public override double Speed => base.Speed * 1.3;

    public override void Overtake(string weather)
    {
        if (this.Car.Tyre.Name.Equals("Ultrasoft"))
        {
            base.TotalTime += SpecialOvertakeTime;
        }

        if (weather.Equals("Foggy"))
        {
            this.Status = "Crashed";
            this.CanRace = false;
        }
    }
}