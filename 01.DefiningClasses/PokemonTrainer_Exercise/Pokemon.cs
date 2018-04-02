namespace PokemonTrainer_Exercise
{
    public class Pokemon
    {
        private string name;
        private string element;

        public Pokemon(string name, string element, int health)
        {
            this.name = name;
            this.element = element;
            this.Health = health;
        }

        public string Name => this.name;

        public string Element => this.element;

        public int Health { get; set; }
    }
}