using System.Collections.Generic;

namespace PokemonTrainer_Exercise
{
    public class Trainer
    {
        private string name;

        public Trainer(string name, int badgesNumber, List<Pokemon> pokemons)
        {
            this.name = name;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name => this.name;

        public int BadgesNumber { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public void LowerPokemonsHealt()
        {
            Pokemons.RemoveAll(p => p.Health <= 10);
            Pokemons.ForEach(p => p.Health -= 10);
        }
    }
}