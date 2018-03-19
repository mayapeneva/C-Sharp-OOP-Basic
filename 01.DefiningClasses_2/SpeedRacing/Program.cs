using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var cars = new Dictionary<string, Car>();

        var n = int.Parse(Console.ReadLine());
        GatherAllCarsInfo(cars, n);

        DriveCars(cars);

        PrintResult(cars);
    }

    private static void PrintResult(Dictionary<string, Car> cars)
    {
        foreach (var car in cars.Values)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
        }
    }

    private static void DriveCars(Dictionary<string, Car> cars)
    {
        string line;
        while ((line = Console.ReadLine()) != "End")
        {
            var args = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var carModel = args[1];
            var distance = int.Parse(args[2]);

            if (!cars[carModel].CouldCarBeDriven(distance))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }

    private static void GatherAllCarsInfo(Dictionary<string, Car> cars, int n)
    {
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = input[0];
            var fuelAmount = double.Parse(input[1]);
            var fuelConsumption = double.Parse(input[2]);

            cars[model] = new Car(model, fuelAmount, fuelConsumption);
        }
    }
}