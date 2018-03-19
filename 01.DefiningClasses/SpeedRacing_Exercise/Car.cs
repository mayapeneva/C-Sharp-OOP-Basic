using System;

namespace SpeedRacing_Exercise
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double distance;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumption = fuelConsumption;
        }

        public string Model => this.model;
        public double FuelAmount => this.fuelAmount;
        public double FuelConsumptipon => this.fuelConsumption;
        public double Distance => this.distance;

        public void CarMovesOrNot(double kms)
        {
            if (fuelAmount >= kms * fuelConsumption)
            {
                this.fuelAmount -= kms * fuelConsumption;
                this.distance += kms;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
