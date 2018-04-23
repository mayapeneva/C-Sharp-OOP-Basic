public class LightSoftware : Software
{
    private const int CapacityIncrease = 3 / 2;
    private const int MemoryDecrease = 1 / 2;

    public LightSoftware(string name, string type, int capacityConsumption, int memoryConsumption)
        : base(name, type, capacityConsumption, memoryConsumption)
    {
    }

    public override int CapacityConsumption
    {
        protected set { base.CapacityConsumption = value * CapacityIncrease; }
    }

    public override int MemoryConsumption
    {
        protected set { base.MemoryConsumption = value * MemoryDecrease; }
    }
}