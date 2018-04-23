public abstract class Monuments
{
    private string name;

    protected Monuments(string name)
    {
        this.name = name;
    }

    public abstract int Affinity { get; }

    public override string ToString()
    {
        return $"{this.name}, ";
    }
}