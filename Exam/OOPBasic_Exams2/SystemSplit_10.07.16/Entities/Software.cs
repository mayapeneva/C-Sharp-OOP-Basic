public abstract class Software
{
    private int capacityConsumption;
    private int memoryConsumption;
    private string name;
    private string type;

    protected Software(string name, string type, int capacityConsumption, int memoryConsumption)
    {
        this.name = name;
        this.type = type;
        this.CapacityConsumption = capacityConsumption;
        this.MemoryConsumption = memoryConsumption;
    }

    public string Name => this.name;

    public string Type => this.type;

    public virtual int CapacityConsumption
    {
        get { return this.capacityConsumption; }
        protected set { this.capacityConsumption = value; }
    }

    public virtual int MemoryConsumption
    {
        get { return this.memoryConsumption; }
        protected set { this.memoryConsumption = value; }
    }

    public override string ToString()
    {
        return this.Name;
    }
}