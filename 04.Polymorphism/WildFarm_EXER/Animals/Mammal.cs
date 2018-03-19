namespace WildFarm_EXER.Animals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string animalName, string animalType, double animalWeight, string livingRegion, Food food)
            : base(animalName, animalType, animalWeight, food)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get { return this.livingRegion; }
            private set { this.livingRegion = value; }
        }
    }
}