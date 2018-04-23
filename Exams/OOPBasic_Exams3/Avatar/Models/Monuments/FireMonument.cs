public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.fireAffinity = fireAffinity;
    }

    public override int IncreaseTotalPower()
    {
        return this.fireAffinity / 100;
    }

    public override string ToString()
    {
        return base.ToString() + $"Fire Affinity: {this.fireAffinity}";
    }
}