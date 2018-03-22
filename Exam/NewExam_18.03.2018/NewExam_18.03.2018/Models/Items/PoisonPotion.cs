public class PoisonPotion : Item
{
    private const string PoisonPotionName = "PoisonPotion";
    private const int PoisonPotionWeight = 5;

    public PoisonPotion()
        : base(PoisonPotionName, PoisonPotionWeight)
    {
    }

    public override void AffectCharacter(Character character)
    {
        base.AffectCharacter(character);
        character.ChangeHealth(-20);
    }
}