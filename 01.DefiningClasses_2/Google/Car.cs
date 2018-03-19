public class Car
{
    public Car(string model, string speed)
    {
        this.Model = model;
        this.Speed = speed;
    }

    public string Model { get; }
    public string Speed { get; }

    public override string ToString()
    {
        return $"{this.Model} {this.Speed}";
    }
}