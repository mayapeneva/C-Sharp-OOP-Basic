using System;
using System.Text;

public abstract class Provider : IProvider
{
    private readonly string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.id = id;
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException("EnergyOutput");
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"{this.GetType().ToString().Replace("Provider", "")} Provider - {this.id}");
        result.AppendLine($"Energy Output: {this.EnergyOutput}");

        return result.ToString().Trim();
    }
}