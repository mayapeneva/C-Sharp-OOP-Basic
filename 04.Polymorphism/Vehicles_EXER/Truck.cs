using System;

namespace Vehicles_EXER
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            var result = string.Empty;
            var fuelToDriveDistance = distance * (this.FuelConsumption + 1.6);
            if (fuelToDriveDistance <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelToDriveDistance;
                result = $"Truck travelled {distance} km";
            }
            else
            {
                result = "Truck needs refueling";
            }

            return result;
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            base.FuelQuantity += fuel * 0.95;
        }
    }
}
