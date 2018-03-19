using System.Text;

public class Car
{
    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
    }

    public string Model { get; }
    public Engine Engine { get; }
    public int Weight { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"{this.Model}:");
        result.AppendLine($"  {this.Engine.Model}:");
        result.AppendLine($"    Power: {this.Engine.Power}");

        var displacement = this.Engine.Displacement != default(int) ? this.Engine.Displacement.ToString() : "n/a";
        result.AppendLine($"    Displacement: {displacement}");

        var efficiency = this.Engine.Efficiency != default(string) ? this.Engine.Efficiency : "n/a";
        result.AppendLine($"    Efficiency: {efficiency}");

        var weight = this.Weight != default(int) ? this.Weight.ToString() : "n/a";
        result.AppendLine($"  Weight: {weight}");

        var color = this.Color != default(string) ? this.Color : "n/a";
        result.AppendLine($"  Color: {color}");

        return result.ToString().Trim();
    }
}