using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                var car = new Car(input[0])
                {
                    Engine = { speed = int.Parse(input[1]), power = int.Parse(input[2]) },
                    Cargo = { weight = int.Parse(input[3]), type = input[4] },
                    Tires =
                    {
                        new Tire{pressure = double.Parse(input[5]), age = int.Parse(input[6])},
                        new Tire{pressure = double.Parse(input[7]), age = int.Parse(input[8])},
                        new Tire{pressure = double.Parse(input[9]), age = int.Parse(input[10])},
                        new Tire{pressure = double.Parse(input[11]), age = int.Parse(input[12])}
                    }
                };

                cars.Add(car);
            }

            var command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(c => c.Tires.Any(t => t.pressure < 1)))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else
            {
                foreach (var car in cars.Where(c => c.Engine.power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }
}