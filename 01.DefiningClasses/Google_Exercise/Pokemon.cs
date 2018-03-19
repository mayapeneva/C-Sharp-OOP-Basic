namespace Google_Exercise
{
    public class Pokemon
    {
        private string pokemonName;
        public string pokemonType;

        public Pokemon(string pokemonName, string pokemonType)
        {
            this.pokemonName = pokemonName;
            this.pokemonType = pokemonType;
        }

        public string PokemonName => this.pokemonName;
    }
}
