using System;

namespace PizzaCalories_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var input = Console.ReadLine().Split();
                while (input[0] != "END")
                {
                    switch (input[0])
                    {
                        case "Pizza":
                            CalculateAndPrintPizzasCallories(input);
                            break;

                        case "Dough":
                            var dough = new Dough(input[1], input[2], double.Parse(input[3]));
                            Console.WriteLine($"{dough.GetDoughCalories():f2}");
                            break;

                        case "Topping":
                            var topping = new Topping(input[1], double.Parse(input[2]));
                            Console.WriteLine($"{topping.GetToppingCalories():f2}");
                            break;
                    }

                    input = Console.ReadLine().Split();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CalculateAndPrintPizzasCallories(string[] input)
        {
            var pizza = new Pizza(input[1]);
            var toppingsNumber = int.Parse(input[2]);
            if (toppingsNumber < 0 || toppingsNumber > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            input = Console.ReadLine().Split();
            pizza.Dough = new Dough(input[1], input[2], double.Parse(input[3]));

            for (int i = 0; i < toppingsNumber; i++)
            {
                input = Console.ReadLine().Split();
                pizza.AddTopping(new Topping(input[1], double.Parse(input[2])));
            }

            Console.WriteLine($"{pizza.Name} - {pizza.GetAllCalories():f2} Calories.");
        }
    }
}