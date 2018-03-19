using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var people = new List<Person>();

        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = input[0];
            var age = int.Parse(input[1]);

            people.Add(new Person(name, age));
        }

        foreach (var person in people.OrderBy(p => p.Name))
        {
            if (person.Age > 30)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}