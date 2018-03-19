using System;

public class Car
{
    private const double MaxFuelTankCapacity = 160.0;
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    protected double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            this.fuelAmount = value > MaxFuelTankCapacity ? MaxFuelTankCapacity : value;
        }
    }

    public Tyre Tyre { get; private set; }

    public double CalculateSpeed()
    {
        return (this.Hp + this.Tyre.Degradation) / this.FuelAmount;
    }

    public void CompleteLap(int trackLength, double fuelConsumptionPerKm)
    {
        this.FuelAmount -= trackLength * fuelConsumptionPerKm;
        this.Tyre.CompleteLap();
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public bool IfTyreNameEquals(string name)
    {
        return this.Tyre.Name.Equals(name);
    }
}