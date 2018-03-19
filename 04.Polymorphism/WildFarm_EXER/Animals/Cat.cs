namespace WildFarm_EXER.Animals
{
    public class Cat : Felime
    {
        private string breed;

        public Cat(string animalName, string animalType, double animalWeight, string livingRegion, string breed, Food food)
            : base(animalName, animalType, animalWeight, livingRegion, food)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return this.breed; }
            private set { this.breed = value; }
        }

        public override string MakeSound()
        {
            return "Meowwww";
        }

        public override void Eat()
        {
        }

        public override string ToString()
        {
            return $"{nameof(Cat)}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten.Quantity}]";
        }
    }
}