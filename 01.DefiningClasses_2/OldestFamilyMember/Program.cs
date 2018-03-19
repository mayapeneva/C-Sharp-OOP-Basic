using System;

public class Program
{
    public static void Main()
    {
        var family = new Family();

        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = input[0];
            var age = int.Parse(input[1]);

            family.AddMemeber(new Person(name, age));
        }

        var oldestPerson = family.GetOldestMember();
        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}