using System;
using WildFarm_EXER.Foods;

namespace WildFarm_EXER.Animals
{
    public class Zebra : Mammal
    {
        public Zebra(string animalName, string animalType, double animalWeight, string livingRegion, Food food)
            : base(animalName, animalType, animalWeight, livingRegion, food)
        {
        }

        public override string MakeSound()
        {
            return "Zs";
        }

        public override void Eat()
        {
            if (this.FoodEaten is Meat)
            {
                this.FoodEaten.Quantity = 0;
                throw new ArgumentException($"{nameof(Zebra)}s are not eating that type of food!");
            }
        }

        public override string ToString()
        {
            return $"{nameof(Zebra)}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten.Quantity}]";
        }
    }
}