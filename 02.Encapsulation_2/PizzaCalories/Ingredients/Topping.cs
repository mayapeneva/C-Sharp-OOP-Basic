using System;

public class Topping
{
    private string toppingType;
    private double weight;

    public Topping(string toppingType, double weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    public string ToppingType
    {
        get { return this.toppingType; }
        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies"
                && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.toppingType = value;
        }
    }

    public double Weight
    {
        get { return this.weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.toppingType} weight should be in the range [1..50].");
            }

            this.weight = value;
        }
    }

    public double GetCalories()
    {
        return (this.weight * 2) * this.GetToppingModifier();
    }

    private double GetToppingModifier()
    {
        switch (this.ToppingType.ToLower())
        {
            case "meat":
                return 1.2;

            case "veggies":
                return 0.8;

            case "cheese":
                return 1.1;

            case "sauce":
                return 0.9;

            default:
                return 1;
        }
    }
}