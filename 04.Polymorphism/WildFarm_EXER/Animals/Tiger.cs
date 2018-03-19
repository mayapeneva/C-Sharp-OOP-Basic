using System;
using WildFarm_EXER.Foods;

namespace WildFarm_EXER.Animals
{
    public class Tiger : Felime
    {
        public Tiger(string animalName, string animalType, double animalWeight, string livingRegion, Food food)
            : base(animalName, animalType, animalWeight, livingRegion, food)
        {
        }

        public override string MakeSound()
        {
            return "ROAAR!!!";
        }

        public override void Eat()
        {
            if (this.FoodEaten is Vegetable)
            {
                this.FoodEaten.Quantity = 0;
                throw new ArgumentException($"{nameof(Tiger)}s are not eating that type of food!");
            }
        }

        public override string ToString()
        {
            return $"{nameof(Tiger)}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten.Quantity}]";
        }
    }
}