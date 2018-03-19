using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private double money;
    private List<Product> products;

    public Person(string name, double money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<Product>();
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

    public double Money
    {
        get => this.money;
        private set
        {
            if (value < 0)
            {
                throw new Exception("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public IReadOnlyCollection<Product> Products
    {
        get { return this.products; }
    }

    public bool HaveEnoughMoney(double cost)
    {
        return this.money >= cost;
    }

    public void BuysProduct(Product product)
    {
        this.products.Add(product);
        this.money -= product.Cost;
    }

    public override string ToString()
    {
        if (this.Products.Count == 0)
        {
            return $"{this.Name} - Nothing bought";
        }

        return $"{this.Name} - {string.Join(", ", this.products.Select(p => p.Name))}";
    }
}