public interface IHarvester : IMiner
{
    double OreOutput { get; }

    double EnergyRequirement { get; }
}