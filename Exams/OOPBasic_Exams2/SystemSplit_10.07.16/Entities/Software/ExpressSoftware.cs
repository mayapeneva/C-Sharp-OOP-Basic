public class ExpressSoftware : Software
{
    private const int MemoryIncrease = 2;

    public ExpressSoftware(string name, string type, int capacityConsumption, int memoryConsumption)
        : base(name, type, capacityConsumption, memoryConsumption)
    {
    }

    public override int MemoryConsumption
    {
        protected set { base.MemoryConsumption = value * MemoryIncrease; }
    }
}