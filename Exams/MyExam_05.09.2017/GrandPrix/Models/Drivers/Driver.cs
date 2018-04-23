public abstract class Driver
{
    private const double NormalOvertakeTime = 0.02;

    private double totalТime;
    private double speed;
    private bool canRace;
    private string status;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.CanRace = true;
    }

    public string Name { get; }

    public Car Car { get; }

    public double FuelConsumptionPerKm { get; }

    public virtual double Speed
    {
        get { return (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount; }
        protected set { this.speed = value; }
    }

    public double TotalTime
    {
        get { return this.totalТime; }
        protected set { this.totalТime = value; }
    }

    public bool CanRace
    {
        get
        {
            return this.canRace;
        }
        protected set
        {
            if (this.Status != string.Empty || this.Car.Status != string.Empty || this.Car.Tyre.Status != string.Empty)
            {
                this.canRace = false;
            }

            this.canRace = true;
        }
    }

    public string Status
    {
        get { return this.status; }
        protected set
        {
            if (this.Car.Tyre.Status != string.Empty)
            {
                this.status = this.Car.Tyre.Status;
                this.CanRace = false;
            }

            if (this.Car.Status != string.Empty)
            {
                this.status = this.Car.Status;
                this.CanRace = false;
            }

            this.status = value;
        }
    }

    public void Box()
    {
        this.totalТime += 20;
    }

    public void ChangeTime(int trackLength)
    {
        this.totalТime += 60 / (trackLength / this.Speed);
    }

    public void GetOvertaken(string weather)
    {
        this.totalТime -= NormalOvertakeTime;
    }

    public virtual void Overtake(string weather)
    {
        this.totalТime += NormalOvertakeTime;
    }
}