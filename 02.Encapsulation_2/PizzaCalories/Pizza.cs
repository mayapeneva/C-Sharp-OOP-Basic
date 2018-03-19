using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public void AddDough(Dough dough)
    {
        this.dough = dough;
    }

    public void AddTopping(Topping topping)
    {
        this.toppings.Add(topping);
    }

    public int ToppingsCount()
    {
        return this.toppings.Count;
    }

    public double GetCalories()
    {
        if (this.toppings.Count < 1 || this.toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

        return this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());
    }

    public override string ToString()
    {
        return $"{this.name} - {this.GetCalories():f2} Calories.";
    }
}