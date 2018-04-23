public class Car
{
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                this.Status = "Out of fuel";
            }

            if (value > 160)
            {
                value = 160;
            }

            this.fuelAmount = value;
        }
    }

    public Tyre Tyre { get; private set; }

    public string Status { get; private set; }

    public void ReduceFuel(double fuelDecrease)
    {
        this.FuelAmount -= fuelDecrease;
    }

    public void DegradateTyre()
    {
        this.Tyre.Degradate();
    }

    public void Refuel(double fuelQuantity)
    {
        this.FuelAmount += fuelQuantity;
        this.Status = string.Empty;
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
        this.Tyre.Status = string.Empty;
    }
}