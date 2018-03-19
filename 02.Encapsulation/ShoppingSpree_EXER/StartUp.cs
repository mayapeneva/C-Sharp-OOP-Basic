using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var peopleInput = Console.ReadLine().Split(';');
                var people = new Dictionary<string, Person>();
                foreach (string person in peopleInput)
                {
                    var pers = person.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    people[pers[0]] = new Person(pers[0], decimal.Parse(pers[1]));
                }

                var productInput = Console.ReadLine().Split(';');
                var products = new Dictionary<string, Product>();
                foreach (string product in productInput)
                {
                    var prod = product.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    products[prod[0]] = new Product(prod[0], decimal.Parse(prod[1]));
                }

                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                while (command[0] != "END")
                {
                    people[command[0]].BuyProductsOrNot(products[command[1]]);

                    command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                }

                PrintResult(people);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintResult(Dictionary<string, Person> people)
        {
            foreach (var prsn in people)
            {
                Console.WriteLine(prsn.Value.Products.Count > 0
                    ? $"{prsn.Value.Name} - {string.Join(", ", prsn.Value.Products.Select(p => p.Name))}"
                    : $"{prsn.Value.Name} - Nothing bought");
            }
        }
    }
}