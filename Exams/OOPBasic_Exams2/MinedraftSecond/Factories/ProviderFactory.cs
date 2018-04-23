using System.Collections.Generic;

public class ProviderFactory
{
    public Provider CreateProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);
        if (type.Equals("Solar"))
        {
            return new SolarProvider(id, energyOutput);
        }

        return new PressureProvider(id, energyOutput);
    }
}