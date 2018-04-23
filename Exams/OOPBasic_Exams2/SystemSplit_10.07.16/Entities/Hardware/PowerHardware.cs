public class PowerHardware : Hardware
{
    private const int CapacityDecrease = 1 / 4;
    private const int MemoryIncrease = 7 / 4;

    public PowerHardware(string name, string type, int maxCapacity, int maxMemory)
        : base(name, type, maxCapacity, maxMemory)
    {
    }

    public override int MaxCapacity
    {
        protected set { base.MaxCapacity = value * CapacityDecrease; }
    }

    public override int MaxMemory
    {
        protected set { base.MaxMemory = value * MemoryIncrease; }
    }
}