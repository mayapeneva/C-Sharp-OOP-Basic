using System;

public class CharacterFactory
{
    public Character CreateCharacter(string characterType, string name, string factionString)
    {
        Faction faction;
        var ifParsed = Enum.TryParse(factionString, out faction);
        if (!ifParsed)
        {
            throw new ArgumentException($"Invalid faction \"{factionString}\"!");
        }

        if (!characterType.Equals("Warrior") && !characterType.Equals("Cleric"))
        {
            throw new ArgumentException($"Invalid character type \"{characterType}\"");
        }

        switch (characterType)
        {
            case "Warrior":
                return new Warrior(name, faction);

            case "Cleric":
                return new Cleric(name, faction);

            default:
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
        }
    }
}