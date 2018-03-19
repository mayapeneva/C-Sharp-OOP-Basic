using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var person = new Person();
        if (input.Length > 1)
        {
            person.Name = $"{input[0]} {input[1]}";
        }
        else
        {
            person.BirthDay = DateTime.ParseExact(input[0], "d/M/yyyy", null);
        }

        var family = new List<Person>();
        GatherAllFamilyInfo(person, family);
        PrintResult(person);
    }

    private static void PrintResult(Person person)
    {
        Console.WriteLine(person.ToString());

        Console.WriteLine("Parents:");
        foreach (var parent in person.Parents)
        {
            Console.WriteLine(parent.ToString());
        }

        Console.WriteLine("Children:");
        foreach (var child in person.Children)
        {
            Console.WriteLine(child.ToString());
        }
    }

    private static void GatherAllFamilyInfo(Person person, List<Person> family)
    {
        string line;
        while ((line = Console.ReadLine()) != "End")
        {
            if (!line.Contains("-"))
            {
                var tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = $"{tokens[0]} {tokens[1]}";
                var dob = DateTime.ParseExact(tokens[2], "d/M/yyyy", null);
                if (person.Name != default(string) && person.Name.Equals(name))
                {
                    person.BirthDay = dob;
                }
                else if (person.BirthDay != default(DateTime) && person.BirthDay.Equals(dob))
                {
                    person.Name = name;
                }
                else if (!family.Any(p => p.Name.Equals(name)) && !family.Any(p => p.BirthDay.Equals(dob)))
                {
                    family.Add(new Person(name, dob));
                }
                else if (family.Any(p => p.Name.Equals(name)))
                {
                    family.First(p => p.Name.Equals(name)).BirthDay = dob;
                }
                else if (family.Any(p => p.BirthDay.Equals(dob)))
                {
                    family.First(p => p.BirthDay.Equals(dob)).Name = name;
                }
            }
            else
            {
                var tokens = line.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                var firstPart = tokens[0];
                var secondPart = tokens[1];
                if (firstPart.Contains(' '))
                {
                    if (secondPart.Contains(' '))
                    {
                        if (person.Name.Equals(firstPart))
                        {
                            person.Children.Add(new Person(secondPart));
                        }
                        else if (person.Name.Equals(secondPart))
                        {
                            person.Parents.Add(new Person(firstPart));
                        }
                        else
                        {
                            var p = new Person(firstPart);
                            p.Children.Add(new Person(secondPart));
                            family.Add(p);
                        }
                    }
                    else
                    {
                        var dob = DateTime.ParseExact(secondPart, "d/M/yyyy", null);
                        if (person.Name.Equals(firstPart))
                        {
                            person.Children.Add(new Person(dob));
                        }
                        else if (person.BirthDay.Equals(dob))
                        {
                            person.Parents.Add(new Person(firstPart));
                        }
                        else
                        {
                            var p = new Person(firstPart);
                            p.Children.Add(new Person(dob));
                            family.Add(p);
                        }
                    }
                }
                else
                {
                    var dob = DateTime.ParseExact(firstPart, "d/M/yyyy", null);
                    if (secondPart.Contains(' '))
                    {
                        if (person.BirthDay.Equals(dob))
                        {
                            person.Children.Add(new Person(secondPart));
                        }
                        else if (person.Name.Equals(secondPart))
                        {
                            person.Parents.Add(new Person(dob));
                        }
                        else
                        {
                            var p = new Person(dob);
                            p.Children.Add(new Person(secondPart));
                            family.Add(p);
                        }
                    }
                    else
                    {
                        var secondDOB = DateTime.ParseExact(secondPart, "d/M/yyyy", null);
                        if (person.BirthDay.Equals(dob))
                        {
                            person.Children.Add(new Person(secondDOB));
                        }
                        else if (person.BirthDay.Equals(secondDOB))
                        {
                            person.Parents.Add(new Person(dob));
                        }
                        else
                        {
                            var p = new Person(dob);
                            p.Children.Add(new Person(secondDOB));
                            family.Add(p);
                        }
                    }
                }
            }
        }
    }
}