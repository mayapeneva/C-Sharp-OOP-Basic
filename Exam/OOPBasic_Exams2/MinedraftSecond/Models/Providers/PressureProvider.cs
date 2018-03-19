public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        base.EnergyOutput = energyOutput * 3 / 2;
    }
}