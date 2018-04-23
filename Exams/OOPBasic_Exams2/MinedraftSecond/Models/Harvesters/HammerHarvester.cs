public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        base.OreOutput = oreOutput * 3;
        base.EnergyRequirement = energyRequirement * 2;
    }
}