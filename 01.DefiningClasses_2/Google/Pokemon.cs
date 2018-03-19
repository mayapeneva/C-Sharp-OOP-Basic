public class Pokemon
{
    public Pokemon(string name, string type)
    {
        this.Name = name;
        this.Type = type;
    }

    public string Name { get; }
    public string Type { get; }

    public override string ToString()
    {
        return $"{this.Name} {this.Type}";
    }
}