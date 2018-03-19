public abstract class Tyre
{
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name { get; }

    public double Hardness { get; }

    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 0)
            {
                this.Status = "Blown Tyre";
            }

            this.degradation = value;
        }
    }

    public virtual void Degradate()
    {
        this.Degradation -= this.Hardness;
    }

    public string Status { get; set; }
}