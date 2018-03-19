public class Car
{
    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelConsumption;
    }

    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumption { get; set; }
    public int DistanceTraveled { get; set; }

    public bool CouldCarBeDriven(int distance)
    {
        var ifCarCanBeDriven = false;
        if (distance * this.FuelConsumption <= this.FuelAmount)
        {
            this.FuelAmount -= distance * this.FuelConsumption;
            this.DistanceTraveled += distance;
            ifCarCanBeDriven = true;
        }

        return ifCarCanBeDriven;
    }
}