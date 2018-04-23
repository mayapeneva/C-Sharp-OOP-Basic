using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DumpManager
{
    private Dictionary<string, Hardware> dumpster;

    public DumpManager()
    {
        this.dumpster = new Dictionary<string, Hardware>();
    }

    public void Dump(string hardwareComponentName, Hardware hardware)
    {
        this.dumpster.Add(hardwareComponentName, hardware);
    }

    public Hardware Restore(string hardwareComponentName)
    {
        if (this.dumpster.ContainsKey(hardwareComponentName))
        {
            var hardware = this.dumpster[hardwareComponentName];
            this.dumpster.Remove(hardwareComponentName);
            return hardware;
        }

        return null;
    }

    public void Destroy(string hardwareComponentName)
    {
        if (this.dumpster.ContainsKey(hardwareComponentName))
        {
            this.dumpster.Remove(hardwareComponentName);
        }
    }

    public string DumpAnalyze()
    {
        var result = new StringBuilder();
        result.AppendLine("Dump Analysis");
        result.AppendLine($"Power Hardware Components: {this.dumpster.Count(h => h.Value.Type.Equals("Power"))}");
        result.AppendLine($"Heavy Hardware Components: {this.dumpster.Count(h => h.Value.Type.Equals("Heavy"))}");
        result.AppendLine($"Express Software Components: {this.dumpster.Sum(h => h.Value.ExpressSoftwareCount)}");
        result.AppendLine($"Light Software Components: {this.dumpster.Sum(h => h.Value.LightSoftwareCount)}");
        result.AppendLine($"Total Dumped Memory: {this.dumpster.Sum(hw => hw.Value.GetMemoryTaken())}");
        result.AppendLine($"Total Dumped Capacity: {this.dumpster.Sum(hw => hw.Value.GetCapacityTaken())}");

        return result.ToString().Trim();
    }
}