using System.Collections.Generic;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower * 3 / 2, acceleration, suspension * 3 / 4, durability)
    {
        this.addOns = new List<string>();
    }

    public override void GetTuned(int tuneIndex, string addOn)
    {
        base.GetTuned(tuneIndex, addOn);
        this.addOns.Add(addOn);
    }

    public override string ToString()
    {
        var result = this.addOns.Count > 0 ? $"Add-ons: {string.Join(", ", this.addOns)}" : "Add-ons: None";

        return base.ToString() + result;
    }
}