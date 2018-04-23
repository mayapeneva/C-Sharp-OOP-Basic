public class ArmorRepairKit : Item
{
    private const string ArmorRepairKitName = "ArmorRepairKit";
    private const int ArmorRepairKitWeight = 10;

    public ArmorRepairKit()
        : base(ArmorRepairKitName, ArmorRepairKitWeight)
    {
    }

    public override void AffectCharacter(Character character)
    {
        base.AffectCharacter(character);
        character.ChangeArmor();
    }
}