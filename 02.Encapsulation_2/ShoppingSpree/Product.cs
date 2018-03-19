using System;

public class Product
{
    private string name;
    private double cost;

    public Product(string name, double cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public double Cost
    {
        get { return this.cost; }
        private set
        {
            if (value < 0)
            {
                throw new Exception("Cost cannot be negative");
            }

            this.cost = value;
        }
    }

    public void ChangeCost(double newCost)
    {
        if (newCost > this.Cost)
        {
            this.Cost = newCost;
        }
    }
}