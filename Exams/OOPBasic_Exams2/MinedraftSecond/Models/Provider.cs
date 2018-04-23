using System;
using System.Text;

public abstract class Provider : Miner
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException($"{nameof(this.EnergyOutput)}");
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"{this.GetType().Name.Replace("Provider", " Provider")} - {this.Id}");
        result.AppendLine($"Energy Output: {this.EnergyOutput}");

        return result.ToString().Trim();
    }
}