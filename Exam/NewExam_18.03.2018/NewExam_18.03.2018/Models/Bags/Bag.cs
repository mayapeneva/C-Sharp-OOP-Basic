using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Bag
{
    private readonly List<Item> items;

    protected Bag(int capacity = 100)
    {
        this.Capacity = capacity;
        this.items = new List<Item>();
    }

    public int Capacity { get; }
    public int Load => this.Items.Sum(i => i.Weight);
    public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

    public void AddItem(Item item)
    {
        if (this.Load + item.Weight > this.Capacity)
        {
            throw new InvalidOperationException("Bag is full!");
        }

        this.items.Add(item);
    }

    public Item GetItem(string name)
    {
        if (!this.items.Any())
        {
            throw new InvalidOperationException("Bag is empty!");
        }

        if (!this.items.Any(i => i.Name.Equals(name)))
        {
            throw new ArgumentException($"No item with name {name} in bag!");
        }

        var item = this.items.First(i => i.Name.Equals(name));
        return item;
    }
}