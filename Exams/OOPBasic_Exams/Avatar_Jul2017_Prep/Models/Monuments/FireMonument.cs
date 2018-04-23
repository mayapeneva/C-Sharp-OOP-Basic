public class FireMonument : Monuments
{
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.fireAffinity = fireAffinity;
    }

    public override int Affinity
    {
        get { return this.fireAffinity; }
    }

    public override string ToString()
    {
        return base.ToString() + $"Fire Affinity: {this.Affinity}";
    }
}