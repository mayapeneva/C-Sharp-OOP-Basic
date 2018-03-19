namespace WildFarm_EXER.Animals
{
    public abstract class Felime : Mammal
    {
        public Felime(string animalName, string animalType, double animalWeight, string livingRegion, Food food)
            : base(animalName, animalType, animalWeight, livingRegion, food)
        {
        }
    }
}