public class Car
{
    public Car(string model, Engine engine, Cargo cargo, Tire tireOne, Tire tireTwo, Tire tireThree, Tire tireFour)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = new Tire[4];
        this.Tires[0] = tireOne;
        this.Tires[1] = tireTwo;
        this.Tires[2] = tireThree;
        this.Tires[3] = tireFour;
    }

    public string Model { get; }
    public Engine Engine { get; }
    public Cargo Cargo { get; }
    public Tire[] Tires { get; }
}