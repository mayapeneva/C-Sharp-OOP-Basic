namespace WildFarm_EXER.Animals
{
    public abstract class Animal
    {
        private string animalName;
        private string animalType;
        private double animalWeight;
        private Food foodEaten;

        public Animal(string animalName, string animalType, double animalWeight, Food food)
        {
            this.AnimalName = animalName;
            this.AnimalType = animalType;
            this.AnimalWeight = animalWeight;
            this.FoodEaten = food;
        }

        public string AnimalName
        {
            get { return this.animalName; }
            private set { this.animalName = value; }
        }

        public string AnimalType
        {
            get { return this.animalType; }
            private set { this.animalName = value; }
        }

        public double AnimalWeight
        {
            get { return this.animalWeight; }
            private set { this.animalWeight = value; }
        }

        public Food FoodEaten
        {
            get { return this.foodEaten; }
            private set { this.foodEaten = value; }
        }

        public abstract string MakeSound();

        public abstract void Eat();
    }
}