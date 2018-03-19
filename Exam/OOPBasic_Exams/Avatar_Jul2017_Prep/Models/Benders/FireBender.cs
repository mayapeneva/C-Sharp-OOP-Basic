public class FireBender : Benders
{
    private double heatAggression;

    public FireBender(string name, int power, double heatAggression)
        : base(name, power)
    {
        this.heatAggression = heatAggression;
    }

    public override double TotalPower
    {
        get { return this.Power * this.heatAggression; }
    }

    public override string ToString()
    {
        return base.ToString() + $"Heat Aggression: {this.heatAggression:f2}";
    }
}