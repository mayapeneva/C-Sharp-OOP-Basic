public class ShowCar : Car
{
    private int stats;

    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.stats = 0;
    }

    public override void GetTuned(int tuneIndex, string addOn)
    {
        base.GetTuned(tuneIndex, addOn);
        this.stats += tuneIndex;
    }

    public override string ToString()
    {
        return base.ToString() + $"{this.stats} *";
    }
}