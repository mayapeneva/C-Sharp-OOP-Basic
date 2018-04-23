public class WaterBender : Bender
{
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity)
        : base(name, power)
    {
        this.waterClarity = waterClarity;
    }

    public override double CalculateTotalPower()
    {
        return base.Power * this.waterClarity;
    }

    public override string ToString()
    {
        return base.ToString() + $"Water Clarity: {this.waterClarity:f2}";
    }
}