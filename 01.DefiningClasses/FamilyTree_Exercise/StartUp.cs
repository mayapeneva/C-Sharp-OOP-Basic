using System;
using System.Collections.Generic;
using System.Linq;

namespace FamilyTree_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            var personToLookFor = Console.ReadLine();
            var date = new DateTime();
            var ifParsed = DateTime.TryParse(personToLookFor, out date);
            var thePerson = ifParsed ? new Person(date) : new Person(personToLookFor);

            var parents = new List<Person>();
            var children = new List<Person>();
            var input = Console.ReadLine();
            while (input != "End")
            {
                if (input.Contains('-'))
                {
                    var tokens = input.Split(new[] { " - " }, StringSplitOptions.None);
                    var firstBD = new DateTime();
                    var secondBD = new DateTime();

                    ifParsed = DateTime.TryParse(tokens[0], out firstBD);
                    var parent = ifParsed ? new Person(firstBD) : new Person(tokens[0]);
                    if ((ifParsed && firstBD != thePerson.Birthdate)
                        || (!ifParsed && tokens[0] != thePerson.Name))
                    {
                        parents.Add(parent);
                    }

                    ifParsed = DateTime.TryParse(tokens[1], out secondBD);
                    var child = ifParsed ? new Person(secondBD) : new Person(tokens[1]);
                    if ((ifParsed && secondBD != thePerson.Birthdate)
                        || (!ifParsed && tokens[1] != thePerson.Name))
                    {
                        children.Add(child);
                    }
                }
                else
                {
                    var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = tokens[0] + ' ' + tokens[1];
                    var bd = DateTime.Parse(tokens[2]);

                    if (thePerson.Name == name)
                    {
                        thePerson.Birthdate = bd;
                    }
                    else if (thePerson.Birthdate == bd)
                    {
                        thePerson.Name = name;
                    }
                    else if (children.Any(c => c.Name == name))
                    {
                        children.FirstOrDefault(c => c.Name == name).Birthdate = bd;
                    }
                    else if (children.Any(c => c.Birthdate == bd))
                    {
                        children.FirstOrDefault(c => c.Birthdate == bd).Name = name;
                    }
                    else if (parents.Any(p => p.Name == name))
                    {
                        parents.FirstOrDefault(c => c.Name == name).Birthdate = bd;
                    }
                    else if (parents.Any(p => p.Birthdate == bd))
                    {
                        parents.FirstOrDefault(c => c.Birthdate == bd).Name = name;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{thePerson.Name} {thePerson.Birthdate.ToShortDateString()}");

            Console.WriteLine("Parents:");
            foreach (var parent in parents.Where(p => p.Name != default(string)
            && p.Birthdate != default(DateTime)
            && thePerson.Birthdate.Year - p.Birthdate.Year > 15))
            {
                Console.WriteLine($"{parent.Name} {parent.Birthdate.ToShortDateString()}");
            }

            Console.WriteLine("Children:");
            foreach (var child in children.Where(c => c.Name != default(string)
            && c.Birthdate != default(DateTime)
            && c.Birthdate.Year - thePerson.Birthdate.Year > 15))
            {
                Console.WriteLine($"{child.Name} {child.Birthdate.ToShortDateString()}");
            }
        }
    }
}