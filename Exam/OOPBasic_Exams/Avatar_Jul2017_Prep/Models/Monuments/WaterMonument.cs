public class WaterMonument : Monuments
{
    private int waterAffinity;

    public WaterMonument(string name, int fireAffinity)
        : base(name)
    {
        this.waterAffinity = fireAffinity;
    }

    public override int Affinity
    {
        get { return this.waterAffinity; }
    }

    public override string ToString()
    {
        return base.ToString() + $"Water Affinity: {this.Affinity}";
    }
}