using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var cats = new Dictionary<string, Cat>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var breed = args[0];
            var name = args[1];
            var number = double.Parse(args[2]);

            cats[name] = new Cat(name, breed, number);
        }

        var catToPrint = Console.ReadLine();
        var cat = cats[catToPrint];
        if (cat.Breed.Equals("Cymric"))
        {
            Console.WriteLine($"{cats[catToPrint]} {cat.Info:f2}");
        }
        else
        {
            Console.WriteLine($"{cats[catToPrint]} {(int)cat.Info}");
        }
    }
}