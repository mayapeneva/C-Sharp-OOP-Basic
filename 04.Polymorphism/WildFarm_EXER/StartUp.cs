using System;
using WildFarm_EXER.Animals;
using WildFarm_EXER.Foods;

namespace WildFarm_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var animalInput = Console.ReadLine().Split();

            while (animalInput[0] != "End")
            {
                var foodInput = Console.ReadLine().Split();
                Food food = CraeteFood(foodInput);
                Animal animal = CreateAnimal(animalInput, food);

                try
                {
                    Console.WriteLine(animal.MakeSound());
                    animal.Eat();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine(animal.ToString());

                animalInput = Console.ReadLine().Split();
            }
        }

        private static Food CraeteFood(string[] foodInput)
        {
            var quantity = int.Parse(foodInput[1]);
            if (foodInput[0] == "Vegetable")
            {
                return new Vegetable(quantity);
            }

            return new Meat(quantity);
        }

        private static Animal CreateAnimal(string[] animalInput, Food food)
        {
            var aType = animalInput[0];
            var aName = animalInput[1];
            var aWeight = double.Parse(animalInput[2]);
            var aLivingReg = animalInput[3];
            if (aType == "Mouse")
            {
                return new Mouse(aType, aName, aWeight, aLivingReg, food);
            }

            if (aType == "Cat")
            {
                return new Cat(aType, aName, aWeight, aLivingReg, animalInput[4], food);
            }

            if (aType == "Tiger")
            {
                return new Tiger(aType, aName, aWeight, aLivingReg, food);
            }

            return new Zebra(aType, aName, aWeight, aLivingReg, food);
        }
    }
}
