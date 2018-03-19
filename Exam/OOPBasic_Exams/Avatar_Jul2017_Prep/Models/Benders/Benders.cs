public abstract class Benders
{
    private string name;
    private int power;

    protected Benders(string name, int power)
    {
        this.name = name;
        this.power = power;
    }

    public int Power
    {
        get { return this.power; }
    }

    public abstract double TotalPower { get; }

    public override string ToString()
    {
        return $"{this.name}, Power: {this.power}, ";
    }
}