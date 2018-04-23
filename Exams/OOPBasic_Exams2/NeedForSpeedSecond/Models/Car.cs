using System.Text;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.brand = brand;
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.horsepower = horsepower;
        this.acceleration = acceleration;
        this.suspension = suspension;
        this.durability = durability;
    }

    public string Brand => this.brand;

    public string Model => this.model;

    public int Horsepower => this.horsepower;

    public int Suspension => this.suspension;

    public virtual void GetTuned(int tuneIndex, string addOn)
    {
        this.horsepower += tuneIndex;
        this.suspension += tuneIndex / 2;
    }

    public int PerformancePoints { get; private set; }

    public void GetOverallPerformance()
    {
        this.PerformancePoints = (this.Horsepower / this.acceleration) + (this.Suspension + this.durability);
    }

    public void GetEnginePerformance()
    {
        this.PerformancePoints = this.Horsepower / this.acceleration;
    }

    public void GetSuspensionPerformance()
    {
        this.PerformancePoints = this.Suspension + this.durability;
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"{this.brand} {this.model} {this.yearOfProduction}");
        result.AppendLine($"{this.Horsepower} HP, 100 m/h in {this.acceleration} s");
        result.AppendLine($"{this.Suspension} Suspension force, {this.durability} Durability");

        return result.ToString();
    }
}