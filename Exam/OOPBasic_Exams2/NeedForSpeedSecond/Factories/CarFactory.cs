public class CarFactory
{
    public Car CreateCar(string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        if (type.Equals("Performance"))
        {
            return new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        }

        return new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
    }
}