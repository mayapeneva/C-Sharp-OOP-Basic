using System;
using System.Collections.Generic;

public class PerformanceCar : Car
{
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        this.Horsepower = horsepower * 150 / 100;
        this.Suspension = suspension * 75 / 100;
    }

    public List<string> AddOns { get; }

    public override string ToString()
    {
        if (AddOns.Count > 0)
        {
            return base.ToString() + Environment.NewLine + $"Add-ons: {string.Join(", ", AddOns)}";
        }

        return base.ToString() + Environment.NewLine + "Add-ons: None";
    }

    public override void IncreaseParameters(int index, string addOn)
    {
        base.IncreaseParameters(index, addOn);
        this.AddOns.Add(addOn);
    }
}