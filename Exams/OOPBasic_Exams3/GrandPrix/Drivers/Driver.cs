using System;
using System.Collections.Generic;

public abstract class Driver
{
    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TotalTime = 0.0;
    }

    public string Name { get; }
    public Car Car { get; }
    public double FuelConsumptionPerKm { get; }
    public double TotalTime { get; private set; }
    public virtual double Speed => this.Car.CalculateSpeed();
    public string FailureReason { get; private set; }

    public void CompleteLap(int trackLength)
    {
        try
        {
            this.TotalTime += (60 / (trackLength / this.Speed));
            this.Car.CompleteLap(trackLength, this.FuelConsumptionPerKm);
        }
        catch (ArgumentException exception)
        {
            this.FailureReason = exception.Message;
        }
    }

    public void ChangeTyres(List<string> tokens)
    {
        this.TotalTime += 20;

        var tyreType = tokens[0];
        var tyreHardness = double.Parse(tokens[1]);
        switch (tyreType)
        {
            case "Hard":
                this.Car.ChangeTyres(new HardTyre(tyreHardness));
                break;

            case "Ultrasoft":
                var grip = double.Parse(tokens[2]);
                this.Car.ChangeTyres(new UltrasoftTyre(tyreHardness, grip));
                break;
        }
    }

    public void Refuel(double fuelAmount)
    {
        this.TotalTime += 20;
        this.Car.Refuel(fuelAmount);
    }

    public void IncreaseTotalTime(double seconds)
    {
        this.TotalTime += seconds;
    }

    public void DecreaseTotalTime(double seconds)
    {
        this.TotalTime -= seconds;
    }

    public void CarCrashes()
    {
        this.FailureReason = "Crashed";
    }

    public override string ToString()
    {
        return $"{this.Name} {this.TotalTime:f3}";
    }
}