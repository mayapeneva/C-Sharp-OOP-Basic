using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> arguments)
    {
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);
        if (arguments.Count == 4)
        {
            return new HammerHarvester(id, oreOutput, energyRequirement);
        }

        var sonicFactor = int.Parse(arguments[4]);
        return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
    }
}