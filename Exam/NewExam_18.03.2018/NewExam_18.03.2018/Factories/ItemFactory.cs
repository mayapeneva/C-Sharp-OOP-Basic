using System;

public class ItemFactory
{
    public Item CreateItem(string itemName)
    {
        if (!itemName.Equals("ArmorRepairKit")
            && !itemName.Equals("HealthPotion")
            && !itemName.Equals("PoisonPotion"))
        {
            throw new ArgumentException($"Invalid item \"{itemName}\"!");
        }

        switch (itemName)
        {
            case "ArmorRepairKit":
                return new ArmorRepairKit();

            case "HealthPotion":
                return new HealthPotion();

            case "PoisonPotion":
                return new PoisonPotion();

            default:
                throw new ArgumentException($"Invalid item type \"{itemName}\"!");
        }
    }
}