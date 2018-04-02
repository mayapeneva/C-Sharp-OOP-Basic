using System;
using System.Collections.Generic;

namespace SpeedRacing_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new Dictionary<string, Car>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var model = input[0];
                var fuelAmount = double.Parse(input[1]);
                var fuelConsumption = double.Parse(input[2]);

                cars[model] = new Car(model, fuelAmount, fuelConsumption);
            }

            var command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                var carModel = command[1];
                var kms = int.Parse(command[2]);

                cars[carModel].CarMovesOrNot(kms);

                command = Console.ReadLine().Split();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:f2} {car.Value.Distance}");
            }
        }
    }
}