public class Cat
{
    public Cat(string name, string breed, double info)
    {
        this.Name = name;
        this.Breed = breed;
        this.Info = info;
    }

    public string Name { get; }
    public string Breed { get; }
    public double Info { get; }

    public override string ToString()
    {
        return $"{this.Breed} {this.Name}";
    }
}