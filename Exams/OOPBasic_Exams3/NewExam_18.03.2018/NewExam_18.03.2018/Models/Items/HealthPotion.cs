public class HealthPotion : Item
{
    private const string HealthPotionName = "HealthPotion";
    private const int HealthPotionWeight = 5;

    public HealthPotion()
        : base(HealthPotionName, HealthPotionWeight)
    {
    }

    public override void AffectCharacter(Character character)
    {
        base.AffectCharacter(character);
        character.ChangeHealth(20);
    }
}