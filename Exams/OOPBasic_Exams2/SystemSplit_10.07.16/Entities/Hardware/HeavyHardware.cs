public class HeavyHardware : Hardware
{
    private const int CapacityIncrease = 2;
    private const int MemoryDecrease = 3 / 4;

    public HeavyHardware(string name, string type, int maxCapacity, int maxMemory)
        : base(name, type, maxCapacity, maxMemory)
    {
    }

    public override int MaxCapacity
    {
        protected set { base.MaxCapacity = value * CapacityIncrease; }
    }

    public override int MaxMemory
    {
        protected set { base.MaxMemory = value * MemoryDecrease; }
    }
}