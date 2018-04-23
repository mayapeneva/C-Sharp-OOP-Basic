public class EnduranceDriver : Driver
{
    private const double FuelConsumptionPerKmConst = 1.5;
    private const double SpecialOvertakeTime = 0.03;

    public EnduranceDriver(string name, Car car)
        : base(name, car, FuelConsumptionPerKmConst)
    {
    }

    public override void Overtake(string weather)
    {
        if (this.Car.Tyre.Name.Equals("Hard"))
        {
            base.TotalTime += SpecialOvertakeTime;
        }

        if (weather.Equals("Rainy"))
        {
            this.Status = "Crashed";
            this.CanRace = false;
        }
    }
}