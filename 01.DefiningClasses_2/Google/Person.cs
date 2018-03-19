using System.Collections.Generic;
using System.Text;

public class Person
{
    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
    }

    public string Name { get; }
    public Company Company { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Child> Children { get; set; }
    public Car Car { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine(this.Name);

        result.AppendLine("Company:");
        if (this.Company != null)
        {
            result.AppendLine(this.Company.ToString());
        }

        result.AppendLine("Car:");
        if (this.Car != null)
        {
            result.AppendLine(this.Car.ToString());
        }

        result.AppendLine("Pokemon:");
        if (this.Pokemons.Count > 0)
        {
            foreach (var pokemon in this.Pokemons)
            {
                result.AppendLine(pokemon.ToString());
            }
        }

        result.AppendLine("Parents:");
        if (this.Parents.Count > 0)
        {
            foreach (var parent in this.Parents)
            {
                result.AppendLine(parent.ToString());
            }
        }

        result.AppendLine("Children:");
        if (this.Children.Count > 0)
        {
            foreach (var child in this.Children)
            {
                result.AppendLine(child.ToString());
            }
        }

        return result.ToString().Trim();
    }
}