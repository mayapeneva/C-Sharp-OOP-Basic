using System;

public class Program
{
    public static void Main()
    {
        try
        {
            var input = Console.ReadLine();
            var inputTokens = input.Split();
            var pizza = new Pizza(inputTokens[1]);

            input = Console.ReadLine();
            inputTokens = input.Split();
            var flourType = inputTokens[1];
            var backingTechnique = inputTokens[2];
            var weight = double.Parse(inputTokens[3]);
            pizza.AddDough(new Dough(flourType, backingTechnique, weight));

            while ((input = Console.ReadLine()) != "END")
            {
                inputTokens = input.Split();
                var topping = inputTokens[1];
                weight = double.Parse(inputTokens[2]);
                pizza.AddTopping(new Topping(topping, weight));
            }

            Console.WriteLine(pizza.ToString());
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}