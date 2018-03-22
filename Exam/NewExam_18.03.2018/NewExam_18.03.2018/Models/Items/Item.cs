using System;

public abstract class Item
{
    protected Item(string name, int weight)
    {
        this.Name = name;
        this.Weight = weight;
    }

    public string Name { get; }
    public int Weight { get; }

    public virtual void AffectCharacter(Character character)
    {
        if (!character.IsAlive)
        {
            throw new ArgumentException("Must be alive to perform this action!");
        }
    }
}