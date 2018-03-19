public class Engine
{
    public Engine(string model, string power)
    {
        this.Model = model;
        this.Power = power;
    }

    public string Model { get; }
    public string Power { get; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }
}