public class EarthMonument : Monuments
{
    private int earthAffinity;

    public EarthMonument(string name, int earthAffinity)
        : base(name)
    {
        this.earthAffinity = earthAffinity;
    }

    public override int Affinity
    {
        get { return this.earthAffinity; }
    }

    public override string ToString()
    {
        return base.ToString() + $"Earth Affinity: {this.Affinity}";
    }
}