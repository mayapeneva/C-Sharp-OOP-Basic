using System;
using System.Text;

public abstract class Harvester : Miner
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(this.OreOutput)}");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get
        {
            return this.energyRequirement;
        }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException($"{nameof(this.EnergyRequirement)}");
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"{this.GetType().Name.Replace("Harvester", " Harvester")} - {this.Id}");
        result.AppendLine($"Ore Output: {this.OreOutput}");
        result.AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return result.ToString().Trim();
    }
}