using System;

public abstract class Character
{
    private string name;
    private double health;
    private double armor;

    protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction, double restHealMultiplier = 0.2)
    {
        this.Name = name;
        this.BaseHealth = health;
        this.Health = health;
        this.BaseArmor = armor;
        this.Armor = armor;
        this.AbilityPoints = abilityPoints;
        this.Bag = bag;
        this.Faction = faction;
        this.IsAlive = true;
        this.RestHealMultiplier = restHealMultiplier;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace!");
            }

            this.name = value;
        }
    }

    public virtual double BaseHealth { get; }

    public double Health
    {
        get => Math.Max(this.health, 0);
        private set
        {
            if (value <= 0)
            {
                this.IsAlive = false;
            }

            this.health = Math.Min(value, this.BaseHealth);
        }
    }

    public virtual double BaseArmor { get; }

    public double Armor
    {
        get => this.armor;
        private set
        {
            if (value < 0)
            {
                this.armor = 0;
            }

            this.armor = Math.Min(value, this.BaseArmor);
        }
    }

    public double AbilityPoints { get; }
    public Bag Bag { get; }
    public Faction Faction { get; }
    public bool IsAlive { get; private set; }
    public double RestHealMultiplier { get; }

    public void TakeDamage(double hitPoints)
    {
        this.IfAlive();

        if (hitPoints <= this.Armor)
        {
            this.Armor -= hitPoints;
        }
        else
        {
            hitPoints -= this.Armor;
            this.Armor = 0;
            this.Health -= hitPoints;
        }
    }

    public void Rest()
    {
        this.IfAlive();

        this.Health = Math.Min(this.Health + this.BaseHealth * this.RestHealMultiplier, this.BaseHealth);
    }

    public void UseItem(Item item)
    {
        item.AffectCharacter(this);
    }

    public void UseItemOn(Item item, Character character)
    {
        item.AffectCharacter(character);
    }

    public void GiveCharacterItem(Item item, Character character)
    {
        character.ReceiveItem(item);
    }

    public void ReceiveItem(Item item)
    {
        this.Bag.AddItem(item);
    }

    public void ChangeHealth(double hitpoints)
    {
        this.Health = Math.Min(this.BaseHealth, this.Health + hitpoints);
    }

    public void ChangeArmor()
    {
        this.Armor = this.BaseArmor;
    }

    private void IfAlive()
    {
        if (!this.IsAlive)
        {
            throw new ArgumentException("Must be alive to perform this action!");
        }
    }

    public override string ToString()
    {
        var status = this.IsAlive ? "Alive" : "Dead";
        return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
    }
}