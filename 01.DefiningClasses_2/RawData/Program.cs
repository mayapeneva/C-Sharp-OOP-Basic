using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var cars = new List<Car>();
        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = input[0];
            var engineSpeed = int.Parse(input[1]);
            var enginePower = int.Parse(input[2]);
            var cargoWeight = int.Parse(input[3]);
            var cargoType = input[4];
            var tire1Pressure = double.Parse(input[5]);
            var tire1Age = int.Parse(input[6]);
            var tire2Pressure = double.Parse(input[7]);
            var tire2Age = int.Parse(input[8]);
            var tire3Pressure = double.Parse(input[9]);
            var tire3Age = int.Parse(input[10]);
            var tire4Pressure = double.Parse(input[11]);
            var tire4Age = int.Parse(input[12]);

            cars.Add(new Car(model, new Engine(engineSpeed, enginePower), new Cargo(cargoWeight, cargoType), new Tire(tire1Pressure, tire1Age), new Tire(tire2Pressure, tire2Age), new Tire(tire3Pressure, tire3Age), new Tire(tire4Pressure, tire4Age)));
        }

        var command = Console.ReadLine();
        foreach (var car in cars.Where(c => c.Cargo.Type.Equals(command)))
        {
            if ((command.Equals("fragile") && car.Tires.Any(t => t.Pressure < 1))
                || (command.Equals("flamable") && car.Engine.Power > 250))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}