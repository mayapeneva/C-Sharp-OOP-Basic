public abstract class Monument
{
    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get; }

    public abstract int IncreaseTotalPower();

    public override string ToString()
    {
        return $"{this.Name}, ";
    }
}