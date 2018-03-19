using System;

namespace Animals_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var animalInput = Console.ReadLine().Trim();

            while (animalInput != "Beast!")
            {
                var animalInfoInput = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                var animal = animalInput;
                var name = animalInfoInput[0];
                var age = int.Parse(animalInfoInput[1]);
                var gender = animalInfoInput[2];

                try
                {
                    switch (animal.ToLower())
                    {
                        case "cat":
                            var cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            break;
                        case "dog":
                            var dog = new Dog(name, age, gender);
                            Console.WriteLine(dog);
                            break;
                        case "frog":
                            var frog = new Frog(name, age, gender);
                            Console.WriteLine(frog);
                            break;
                        case "kitten":
                            var kitten = new Kitten(name, age, gender);
                            Console.WriteLine(kitten);
                            break;
                        case "tomcat":
                            var tomcat = new Tomcat(name, age, gender);
                            Console.WriteLine(tomcat);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                animalInput = Console.ReadLine().Trim();
            }
        }
    }
}
