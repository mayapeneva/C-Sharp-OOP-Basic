public class WaterBender : Benders
{
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity)
        : base(name, power)
    {
        this.waterClarity = waterClarity;
    }

    public override double TotalPower
    {
        get { return this.Power * this.waterClarity; }
    }

    public override string ToString()
    {
        return base.ToString() + $"Water Clarity: {this.waterClarity:f2}";
    }
}