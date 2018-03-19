using System;

namespace Vehicles_EXER
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public double TankCapacity
        {
            get { return this.tankCapacity; }
            protected set { this.tankCapacity = value; }
        }

        public abstract string Drive(double distance);

        public virtual string DriveEmpty(double distance)
        {
            var result = string.Empty;
            if (distance * this.FuelConsumption <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance * this.FuelConsumption;
                result = $" travelled {distance} km";
            }
            else
            {
                result = " needs refueling";
            }

            return result;
        }

        public abstract void Refuel(double fuel);
    }
}