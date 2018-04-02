using System;

namespace Vehicles_EXER
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            var result = string.Empty;
            var fuelToDriveDistance = distance * (this.FuelConsumption + 1.4);
            if (fuelToDriveDistance <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelToDriveDistance;
                result = $"Bus travelled {distance} km";
            }
            else
            {
                result = "Bus needs refueling";
            }

            return result;
        }

        public override string DriveEmpty(double distance)
        {
            return "Bus" + base.DriveEmpty(distance);
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (fuel > this.TankCapacity)
            {
                throw new ArgumentException("Cannot fit fuel in tank");
            }

            base.FuelQuantity += fuel;
        }
    }
}