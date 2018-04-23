using System;
using System.Text;

public abstract class Harvester : IHarvester
{
    private readonly string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("OreOutput");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("EnergyRequirement");
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"{this.GetType().ToString().Replace("Harvester", "")} Harvester - {this.id}");
        result.AppendLine($"Ore Output: {this.OreOutput}");
        result.AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return result.ToString().Trim();
    }
}