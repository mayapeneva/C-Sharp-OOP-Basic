using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private const double OreOutputDecrease = 0.5;
    private const double EnergyReqDecrease = 0.6;

    private readonly List<Harvester> harvesters;
    private readonly List<Provider> providers;

    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    private double totalStoredEnergy;
    private double totalMinedOre;
    private string mode;

    public DraftManager(HarvesterFactory harvesterFactory, ProviderFactory providerFactory)
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = harvesterFactory;
        this.providerFactory = providerFactory;
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        try
        {
            this.harvesters.Add(this.harvesterFactory.CreateHarvester(arguments));
            return $"Successfully registered {type} Harvester - {id}";
        }
        catch (Exception e)
        {
            return "Harvester is not registered, because of it's " + e.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        try
        {
            this.providers.Add(this.providerFactory.CreateProvider(arguments));
            return $"Successfully registered {type} Provider - {id}";
        }
        catch (Exception e)
        {
            return "Provider is not registered, because of it's " + e.Message;
        }
    }

    public string Day()
    {
        var energyOutputForTheDay = this.providers.Sum(p => p.EnergyOutput);
        var currentTotalEnergyOutput = this.totalStoredEnergy + energyOutputForTheDay;

        var energyRequirementForTheDay = this.harvesters.Sum(h => h.EnergyRequirement);
        energyRequirementForTheDay = this.mode == "Energy" ? 0 : this.mode == "Half" ? energyRequirementForTheDay * EnergyReqDecrease : energyRequirementForTheDay;

        var result = new StringBuilder();
        result.AppendLine("A day has passed.");
        result.AppendLine($"Energy Provided: {energyOutputForTheDay}");
        var oreOutputForTheDay = 0.0;

        if (currentTotalEnergyOutput >= energyRequirementForTheDay)
        {
            energyOutputForTheDay -= energyRequirementForTheDay;

            oreOutputForTheDay = this.harvesters.Sum(h => h.OreOutput);
            oreOutputForTheDay = this.mode == "Energy" ? 0 : this.mode == "Half" ? oreOutputForTheDay * OreOutputDecrease : oreOutputForTheDay;
            this.totalMinedOre += oreOutputForTheDay;
        }
        this.totalStoredEnergy += energyOutputForTheDay;

        result.AppendLine($"Plumbus Ore Mined: {oreOutputForTheDay}");
        return result.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var newMode = arguments[0];
        this.mode = newMode;
        return $"Successfully changed working mode to {newMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        if (this.harvesters.Any(h => h.Id.Equals(id)))
        {
            return this.harvesters.First(h => h.Id.Equals(id)).ToString();
        }

        if (this.providers.Any(h => h.Id.Equals(id)))
        {
            return this.providers.First(h => h.Id.Equals(id)).ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var result = new StringBuilder();
        result.AppendLine("System Shutdown");
        result.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        result.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return result.ToString().Trim();
    }
}