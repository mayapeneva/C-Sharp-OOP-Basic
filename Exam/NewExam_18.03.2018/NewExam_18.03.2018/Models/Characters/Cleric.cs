using System;

public class Cleric : Character, IHealable
{
    private const double ClericBaseHealth = 50;
    private const double ClericBaseArmor = 25;
    private const double ClericAbilityPoints = 40;
    private const double ClericRestHealMultiplier = 0.5;

    public Cleric(string name, Faction faction)
        : base(name, ClericBaseHealth, ClericBaseArmor, ClericAbilityPoints, new Backpack(), faction, ClericRestHealMultiplier)
    {
    }

    public void Heal(Character character)
    {
        if (!this.IsAlive || !character.IsAlive)
        {
            throw new InvalidOperationException("Must be alive to perform this action!");
        }

        if (!this.Faction.Equals(character.Faction))
        {
            throw new InvalidOperationException("Cannot heal enemy character!");
        }

        character.ChangeHealth(this.AbilityPoints);
    }
}