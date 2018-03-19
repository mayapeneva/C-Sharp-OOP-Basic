using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var engines = new List<Engine>();

        var n = int.Parse(Console.ReadLine());
        GatherEngineInfo(engines, n);

        var cars = new List<Car>();
        GatherCarInfo(engines, cars);

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }

    private static void GatherCarInfo(List<Engine> engines, List<Car> cars)
    {
        var m = int.Parse(Console.ReadLine());
        for (int j = 0; j < m; j++)
        {
            var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var engine = engines.First(e => e.Model.Equals(line[1]));
            var car = new Car(line[0], engine);
            if (line.Length == 3)
            {
                var number = 0;
                var ifParsed = int.TryParse(line[2], out number);
                if (ifParsed)
                {
                    car.Weight = number;
                }
                else
                {
                    car.Color = line[2];
                }
            }
            else if (line.Length == 4)
            {
                car.Weight = int.Parse(line[2]);
                car.Color = line[3];
            }

            cars.Add(car);
        }
    }

    private static void GatherEngineInfo(List<Engine> engines, int n)
    {
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var engine = new Engine(input[0], input[1]);
            if (input.Length == 3)
            {
                var number = 0;
                var ifParsed = int.TryParse(input[2], out number);
                if (ifParsed)
                {
                    engine.Displacement = number;
                }
                else
                {
                    engine.Efficiency = input[2];
                }
            }
            else if (input.Length == 4)
            {
                engine.Displacement = int.Parse(input[2]);
                engine.Efficiency = input[3];
            }

            engines.Add(engine);
        }
    }
}