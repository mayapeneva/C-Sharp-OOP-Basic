using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SystemManager
{
    private Dictionary<string, Hardware> system;

    public SystemManager()
    {
        this.system = new Dictionary<string, Hardware>();
    }

    public void RegisterPowerHardware(string name, int capacity, int memory)
    {
        if (!this.system.ContainsKey(name))
        {
            this.system.Add(name, new PowerHardware(name, "Power", capacity, memory));
        }
    }

    public void RegisterHeavyHardware(string name, int capacity, int memory)
    {
        if (!this.system.ContainsKey(name))
        {
            this.system.Add(name, new HeavyHardware(name, "Heavy", capacity, memory));
        }
    }

    public void RegisterExpressSoftware(string hardwareComponentName, string name, int capacity, int memory)
    {
        if (this.system.ContainsKey(hardwareComponentName))
        {
            this.system[hardwareComponentName].AddSoftware(new ExpressSoftware(name, "Express", capacity, memory));
        }
    }

    public void RegisterLightSoftware(string hardwareComponentName, string name, int capacity, int memory)
    {
        if (this.system.ContainsKey(hardwareComponentName))
        {
            this.system[hardwareComponentName].AddSoftware(new LightSoftware(name, "Light", capacity, memory));
        }
    }

    public void ReleaseSoftwareComponent(string hardwareComponentName, string softwareComponentName)
    {
        if (this.system.ContainsKey(hardwareComponentName))
        {
            this.system[hardwareComponentName].ReleaseSoftware(softwareComponentName);
        }
    }

    public string Analyze()
    {
        var maxMemory = this.system.Sum(h => h.Value.MaxMemory);
        var memoryInUse = this.system.Sum(h => h.Value.GetMemoryTaken());
        var maxCapacity = this.system.Sum(h => h.Value.MaxCapacity);
        var capacityInUse = this.system.Sum(h => h.Value.GetCapacityTaken());

        var result = new StringBuilder();
        result.AppendLine("System Analysis");
        result.AppendLine($"Hardware Components: {this.system.Count}");
        result.AppendLine($"Software Components: {this.system.Sum(h => h.Value.SoftwareCount)}");
        result.AppendLine($"Total Operational Memory: {memoryInUse} / {maxMemory}");
        result.AppendLine($"Total Capacity Taken: {capacityInUse} / {maxCapacity}");

        return result.ToString().Trim();
    }

    public Hardware RemoveHardware(string hardwareComponentName)
    {
        if (this.system.ContainsKey(hardwareComponentName))
        {
            var hardware = this.system[hardwareComponentName];
            this.system.Remove(hardwareComponentName);
            return hardware;
        }

        return null;
    }

    public void AddHardware(string hardwareComponentName, Hardware hardware)
    {
        this.system.Add(hardwareComponentName, hardware);
    }

    public string SystemSplit()
    {
        var result = new StringBuilder();
        foreach (Hardware hardware in this.system.Values.OrderByDescending(h => h.Type))
        {
            result.AppendLine(hardware.ToString());
        }

        return result.ToString().Trim();
    }
}