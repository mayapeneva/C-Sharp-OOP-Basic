using System;

public class ShowCar : Car
{
    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
    }

    public int Stars { get; private set; }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine + $"{Stars} *";
    }

    public override void IncreaseParameters(int index, string addOn)
    {
        base.IncreaseParameters(index, addOn);
        this.Stars += index;
    }
}