using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        try
        {
            List<Person> people = GatherAllPeoplesInfo();

            List<Product> products = GatherAllProductsInfo();

            PerformShopping(people, products);

            PrintResult(people);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static void PrintResult(List<Person> people)
    {
        foreach (var person in people)
        {
            Console.WriteLine(person.ToString());
        }
    }

    private static void PerformShopping(List<Person> people, List<Product> products)
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(' ');
            var personName = tokens[0];
            var productName = tokens[1];
            var person = people.FirstOrDefault(p => p.Name.Equals(personName));
            var product = products.FirstOrDefault(p => p.Name.Equals(productName));
            if (person != null && product != null)
            {
                if (person.HaveEnoughMoney(product.Cost))
                {
                    person.BuysProduct(product);
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }
        }
    }

    private static List<Product> GatherAllProductsInfo()
    {
        var products = new List<Product>();
        var productsInput = Console.ReadLine().Trim(';').Split(';').ToArray();
        for (int j = 0; j < productsInput.Length; j++)
        {
            var productsTokens = productsInput[j].Split('=');
            var productName = productsTokens[0];
            var productCost = double.Parse(productsTokens[1]);
            if (products.All(p => !p.Name.Equals(productName)))
            {
                products.Add(new Product(productName, productCost));
            }
            else
            {
                products.First(p => p.Name.Equals(productName)).ChangeCost(productCost);
            }
        }

        return products;
    }

    private static List<Person> GatherAllPeoplesInfo()
    {
        var people = new List<Person>();
        var peopleInput = Console.ReadLine().Trim(';').Split(';').ToArray();
        for (int i = 0; i < peopleInput.Length; i++)
        {
            var peopleTokens = peopleInput[i].Split('=');
            var personName = peopleTokens[0];
            var personMoney = double.Parse(peopleTokens[1]);
            people.Add(new Person(personName, personMoney));
        }

        return people;
    }
}