using System;
using WildFarm_EXER.Foods;

namespace WildFarm_EXER.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string animalName, string animalType, double animalWeight, string livingRegion, Food food)
            : base(animalName, animalType, animalWeight, livingRegion, food)
        {
        }

        public override string MakeSound()
        {
            return "SQUEEEAAAK!";
        }

        public override void Eat()
        {
            if (this.FoodEaten is Meat)
            {
                this.FoodEaten.Quantity = 0;
                throw new ArgumentException($"{nameof(Mouse)}s are not eating that type of food!");
            }
        }

        public override string ToString()
        {
            return $"{nameof(Mouse)}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten.Quantity}]";
        }
    }
}