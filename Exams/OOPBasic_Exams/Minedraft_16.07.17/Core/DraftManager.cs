using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private readonly Dictionary<string, Harvester> harvesters;
    private readonly Dictionary<string, Provider> providers;
    private double totalEnergyStored;
    private double totalMinedOre;
    private string mode;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);
        try
        {
            if (arguments.Count > 4)
            {
                var sonicFactor = int.Parse(arguments[4]);
                this.harvesters.Add(id, new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor));
            }
            else
            {
                this.harvesters.Add(id, new HammerHarvester(id, oreOutput, energyRequirement));
            }
        }
        catch (Exception e)
        {
            return "Harvester is not registered, because of it's " + e.Message;
        }

        return $"Successfully registered {type} Harvester - {id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);
        try
        {
            switch (type)
            {
                case "Solar":
                    this.providers.Add(id, new SolarProvider(id, energyOutput));
                    break;

                case "Pressure":
                    this.providers.Add(id, new PressureProvider(id, energyOutput));
                    break;
            }
        }
        catch (Exception e)
        {
            return "Provider is not registered, because of it's " + e.Message;
        }

        return $"Successfully registered {type} Provider - {id}";
    }

    public string Day()
    {
        var summedEnergyOutput = this.providers.Sum(p => p.Value.EnergyOutput);

        var summedEnergyRequirement = this.harvesters.Sum(h => h.Value.EnergyRequirement);
        var summedOreOutput = this.harvesters.Sum(h => h.Value.OreOutput);
        if (this.mode == "Half")
        {
            summedEnergyRequirement *= 0.6;
            summedOreOutput *= 0.5;
        }
        else if (this.mode == "Energy")
        {
            summedEnergyRequirement = summedOreOutput = 0.0;
        }

        this.totalEnergyStored += summedEnergyOutput;

        if (this.totalEnergyStored < summedEnergyRequirement)
        {
            summedEnergyRequirement = 0.0;
            summedOreOutput = 0.0;
        }

        this.totalEnergyStored -= summedEnergyRequirement;
        this.totalMinedOre += summedOreOutput;

        var result = new StringBuilder();
        result.AppendLine($"A day has passed.");
        result.AppendLine($"Energy Provided: {summedEnergyOutput}");
        result.AppendLine($"Plumbus Ore Mined: {summedOreOutput}");

        return result.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        if (this.harvesters.Any(h => h.Key.Equals(id)))
        {
            return this.harvesters.First(h => h.Key.Equals(id)).Value.ToString();
        }

        if (this.providers.Any(p => p.Key.Equals(id)))
        {
            return this.providers.First(p => p.Key.Equals(id)).Value.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var result = new StringBuilder();
        result.AppendLine("System Shutdown");
        result.AppendLine($"Total Energy Stored: {this.totalEnergyStored}");
        result.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return result.ToString().Trim();
    }
}