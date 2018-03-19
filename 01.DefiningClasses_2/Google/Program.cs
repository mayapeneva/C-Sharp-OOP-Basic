using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var people = new Dictionary<string, Person>();
        GatherAllPeopleInfo(people);

        var name = Console.ReadLine();
        var person = people[name];
        Console.WriteLine(person.ToString());
    }

    private static void GatherAllPeopleInfo(Dictionary<string, Person> people)
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var personName = args[0];
            if (!people.ContainsKey(personName))
            {
                people[personName] = new Person(personName);
            }

            switch (args[1])
            {
                case "company":
                    people[personName].Company = new Company(args[2], args[3], decimal.Parse(args[4]));
                    break;

                case "pokemon":
                    people[personName].Pokemons.Add(new Pokemon(args[2], args[3]));
                    break;

                case "parents":
                    people[personName].Parents.Add(new Parent(args[2], args[3]));
                    break;

                case "children":
                    people[personName].Children.Add(new Child(args[2], args[3]));
                    break;

                case "car":
                    people[personName].Car = new Car(args[2], args[3]);
                    break;
            }
        }
    }
}