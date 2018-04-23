public class EarthBender : Benders
{
    private double groundSaturation;

    public EarthBender(string name, int power, double groundSaturation)
        : base(name, power)
    {
        this.groundSaturation = groundSaturation;
    }

    public override double TotalPower
    {
        get { return this.Power * this.groundSaturation; }
    }

    public override string ToString()
    {
        return base.ToString() + $"Ground Saturation: {this.groundSaturation:f2}";
    }
}