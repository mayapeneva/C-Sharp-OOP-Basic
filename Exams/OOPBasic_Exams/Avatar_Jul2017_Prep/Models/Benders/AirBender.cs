public class AirBender : Benders
{
    private double aerialIntegrity;

    public AirBender(string name, int power, double aerialIntegrity)
        : base(name, power)
    {
        this.aerialIntegrity = aerialIntegrity;
    }

    public override double TotalPower
    {
        get { return this.Power * this.aerialIntegrity; }
    }

    public override string ToString()
    {
        return base.ToString() + $"Aerial Integrity: {this.aerialIntegrity:f2}";
    }
}