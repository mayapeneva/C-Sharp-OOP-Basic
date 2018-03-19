using System;
using System.Collections.Generic;
using System.Linq;

namespace CatLady
{
    public class Program
    {
        public static void Main()
        {
            var cats = new List<Cat>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = data[1];
                var number = double.Parse(data[2]);
                switch (data[0])
                {
                    case "Siamese":
                        cats.Add(new Siamese(name, number));
                        break;

                    case "Cymric":
                        cats.Add(new Cymric(name, number));
                        break;

                    case "StreetExtraordinaire":
                        cats.Add(new StreetExtraordinaire(name, number));
                        break;
                }
            }

            var catName = Console.ReadLine();
            if (cats.Any(c => c.Name.Equals(catName)))
            {
                Console.WriteLine(cats.First(c => c.Name.Equals(catName)).ToString());
            }
        }
    }
}