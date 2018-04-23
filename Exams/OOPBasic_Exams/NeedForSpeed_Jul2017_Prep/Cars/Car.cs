using System.Text;

public abstract class Car
{
    private int yearOfProduction;

    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.yearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand { get; }
    public string Model { get; }
    public int Horsepower { get; protected set; }
    public int Acceleration { get; }
    public int Suspension { get; protected set; }
    public int Durability { get; set; }
    public int PerformancePoints { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"{this.Brand} {this.Model} {this.yearOfProduction}");
        result.AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s");
        result.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return result.ToString().Trim();
    }

    public virtual void IncreaseParameters(int index, string addOn)
    {
        this.Horsepower += index;
        this.Suspension += index * 50 / 100;
    }
}