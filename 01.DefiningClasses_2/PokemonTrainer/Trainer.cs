using System.Collections.Generic;

public class Trainer
{
    public Trainer(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
    }

    public string Name { get; }
    public int BadgesNumber { get; set; }
    public List<Pokemon> Pokemons { get; }
}