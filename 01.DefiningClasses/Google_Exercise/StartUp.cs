using System;
using System.Collections.Generic;
using System.Linq;

namespace Google_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var people = new Dictionary<string, Person>();
            while (line[0] != "End")
            {
                var name = line[0];
                if (!people.ContainsKey(name))
                {
                    people[name] = new Person(name);
                }

                var paramName = line[2];
                switch (line[1])
                {
                    case "company":
                        var department = line[3];
                        var salary = decimal.Parse(line[4]);
                        if (people[name].company.companyName != paramName)
                        {
                            people[name].company = new Company(paramName, department, salary);
                        }
                        else
                        {
                            people[name].company.department = department;
                            people[name].company.salary = salary;
                        }
                        break;
                    case "pokemon":
                        var pokType = line[3];
                        if (people[name].pokemons.All(p => p.PokemonName != paramName))
                        {
                            people[name].pokemons.Add(new Pokemon(paramName, pokType));
                        }
                        else
                        {
                            people[name].pokemons.First(p => p.PokemonName == paramName).pokemonType = pokType;
                        }
                        break;
                    case "parents":
                        var parBD = line[3];
                        if (people[name].parents.All(p => p.ParentName != paramName))
                        {
                            people[name].parents.Add(new Parent(paramName, parBD));
                        }
                        else
                        {
                            people[name].parents.First(p => p.ParentName == paramName).parentBirthday = parBD;
                        }
                        break;
                    case "children":
                        var childBD = line[3];
                        if (people[name].children.All(p => p.ChildName != paramName))
                        {
                            people[name].children.Add(new Child(paramName, childBD));
                        }
                        else
                        {
                            people[name].children.First(p => p.ChildName == paramName).childBirthday = childBD;
                        }
                        break;
                    case "car":
                        var carSpeed = int.Parse(line[3]);
                        if (people[name].car.CarModel != paramName)
                        {
                            people[name].car = new Car(paramName, carSpeed);
                        }
                        else
                        {
                            people[name].car.carSpeed = carSpeed;
                        }
                        break;
                }

                line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            var personsName = Console.ReadLine();
            var result = people.FirstOrDefault(p => p.Key == personsName);
            PrintReslt(result);
        }

        private static void PrintReslt(KeyValuePair<string, Person> result)
        {
            Console.WriteLine(result.Key);

            Console.WriteLine("Company:");
            if (result.Value.company.companyName != default(string))
            {
                Console.WriteLine($"{result.Value.company.companyName} {result.Value.company.department} {result.Value.company.salary:f2}");
            }

            Console.WriteLine("Car:");
            if (result.Value.car.CarModel != default(string))
            {
                Console.WriteLine($"{result.Value.car.CarModel} {result.Value.car.carSpeed}");
            }

            Console.WriteLine("Pokemon:");
            if (result.Value.pokemons.Count > 0)
            {
                foreach (var pokem in result.Value.pokemons)
                {
                    Console.WriteLine($"{pokem.PokemonName} {pokem.pokemonType}");
                }
            }

            Console.WriteLine("Parents:");
            if (result.Value.parents.Count > 0)
            {
                foreach (var parent in result.Value.parents)
                {
                    Console.WriteLine($"{parent.ParentName} {parent.parentBirthday}");
                }
            }

            Console.WriteLine("Children:");
            if (result.Value.children.Count > 0)
            {
                foreach (var child in result.Value.children)
                {
                    Console.WriteLine($"{child.ChildName} {child.childBirthday}");
                }
            }
        }
    }
}
