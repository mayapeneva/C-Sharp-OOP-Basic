public abstract class Bender
{
    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name { get; }
    public int Power { get; }

    public abstract double CalculateTotalPower();

    public override string ToString()
    {
        return $"{this.Name}, Power: {this.Power}, ";
    }
}