using System;

public class Program
{
    public static void Main()
    {
        var animalFactory = new AnimalFactory();

        string animalType;
        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            try
            {
                var animalDetails = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = animalDetails[0];

                var age = 0;
                var ifParsed = int.TryParse(animalDetails[1], out age);
                if (!ifParsed)
                {
                    throw new ArgumentException("Invalid input!");
                }

                var gender = animalDetails[2];

                var animal = animalFactory.CreateAnimal(animalType, name, age, gender);
                if (animal != null)
                {
                    Console.WriteLine(animalType);
                    Console.WriteLine(animal.ToString());
                    Console.WriteLine(animal.ProduceSound());
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}