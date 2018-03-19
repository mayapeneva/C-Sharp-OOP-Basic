using System;

namespace Vehicles_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var carInfo = Console.ReadLine().Split();
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            var truckInfo = Console.ReadLine().Split();
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            var busInfo = Console.ReadLine().Split();
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split();
                var action = command[0];
                var vehicle = command[1];
                var param = double.Parse(command[2]);

                try
                {
                    switch (vehicle)
                    {
                        case "Car":
                            ExecuteCommand(car, action, param);
                            break;
                        case "Truck":
                            ExecuteCommand(truck, action, param);
                            break;
                        case "Bus":
                            ExecuteCommand(bus, action, param);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }

        private static void ExecuteCommand(Vehicle vehicle, string action, double param)
        {
            switch (action)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(param));
                    break;
                case "DriveEmpty":
                    Console.WriteLine(vehicle.DriveEmpty(param));
                    break;
                case "Refuel":
                    vehicle.Refuel(param);
                    break;
            }
        }
    }
}
