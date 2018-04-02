using System;
using System.Collections.Generic;

namespace CarSalesman_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var engines = new List<Engine>();
            GetEnginesInfo(n, engines);

            var m = int.Parse(Console.ReadLine());
            GetCarsInfoAndPrint(engines, m);
        }

        private static void GetEnginesInfo(int n, List<Engine> engines)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var engine = new Engine(input[0], int.Parse(input[1]));
                if (input.Length > 2)
                {
                    var displacement = 0;
                    var ifNumber = int.TryParse(input[2], out displacement);
                    if (!ifNumber)
                    {
                        engine.efficiency = input[2];
                    }
                    else
                    {
                        engine.displacement = displacement;
                    }

                    if (input.Length > 3)
                    {
                        engine.efficiency = input[3];
                    }
                }

                engines.Add(engine);
            }
        }

        private static void GetCarsInfoAndPrint(List<Engine> engines, int m)
        {
            for (int j = 0; j < m; j++)
            {
                var line = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var car = new Car(line[0], line[1]);
                if (line.Length > 2)
                {
                    var weight = 0;
                    var ifNumber = int.TryParse(line[2], out weight);
                    if (!ifNumber)
                    {
                        car.color = line[2];
                    }
                    else
                    {
                        car.weight = weight;
                    }

                    if (line.Length > 3)
                    {
                        car.color = line[3];
                    }
                }

                var resultEngine = car.GetEngine(engines);
                PrintResult(car, resultEngine);
            }
        }

        private static void PrintResult(Car car, Engine resultEngine)
        {
            Console.WriteLine($"{car.model}:");
            Console.WriteLine($"  {car.engineModel}:");
            Console.WriteLine($"    Power: {resultEngine.power}");
            Console.Write("    Displacement: ");
            if (resultEngine.displacement == default(int))
            {
                Console.Write("n/a");
            }
            else
            {
                Console.Write(resultEngine.displacement);
            }
            Console.WriteLine();
            Console.WriteLine($"    Efficiency: {resultEngine.efficiency}");
            Console.Write("  Weight: ");
            if (car.weight == default(int))
            {
                Console.Write("n/a");
            }
            else
            {
                Console.Write(car.weight);
            }
            Console.WriteLine();
            Console.WriteLine($"  Color: {car.color}");
        }
    }
}