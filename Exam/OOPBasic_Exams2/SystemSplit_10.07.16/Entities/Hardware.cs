using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Hardware
{
    private string name;
    private string type;
    private int maxCapacity;
    private int maxMemory;
    private List<Software> softwares;

    protected Hardware(string name, string type, int maxCapacity, int maxMemory)
    {
        this.name = name;
        this.type = type;
        this.MaxCapacity = maxCapacity;
        this.MaxMemory = maxMemory;
        this.softwares = new List<Software>();
    }

    public string Type => this.type;

    public virtual int MaxCapacity
    {
        get { return this.maxCapacity; }
        protected set { this.maxCapacity = value; }
    }

    public virtual int MaxMemory
    {
        get { return this.maxMemory; }
        protected set { this.maxMemory = value; }
    }

    public int SoftwareCount => this.softwares.Count;

    public int ExpressSoftwareCount => this.softwares.Count(s => s.Type.Equals("Express"));

    public int LightSoftwareCount => this.softwares.Count(s => s.Type.Equals("Light"));

    public void AddSoftware(Software software)
    {
        if (this.GetCapacityLeft() >= software.CapacityConsumption)
        {
            this.softwares.Add(software);
        }
    }

    public int GetCapacityLeft()
    {
        return this.MaxCapacity - this.GetCapacityTaken();
    }

    public int GetCapacityTaken()
    {
        return this.softwares.Sum(s => s.CapacityConsumption);
    }

    public int GetMemoryTaken()
    {
        return this.softwares.Sum(s => s.MemoryConsumption);
    }

    public bool CheckIfHardwareContainsSoftware(string softwareName)
    {
        if (this.softwares.Any(s => s.Name.Equals(softwareName)))
        {
            return true;
        }

        return false;
    }

    public void ReleaseSoftware(string softwareName)
    {
        if (this.CheckIfHardwareContainsSoftware(softwareName))
        {
            var softwareToRemove = this.softwares.First(s => s.Name.Equals(softwareName));
            this.softwares.Remove(softwareToRemove);
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"Hardware Component - {this.name}");
        result.AppendLine($"Express Software Components - {this.softwares.Count(s => s.Type.Equals("Express"))}");
        result.AppendLine($"Light Software Components - {this.softwares.Count(s => s.Type.Equals("Light"))}");
        result.AppendLine($"Memory Usage: {this.GetMemoryTaken()} / {this.MaxMemory}");
        result.AppendLine($"Capacity Usage: {this.GetCapacityTaken()} / {this.MaxCapacity}");
        result.AppendLine($"Type: {this.type}");
        if (this.softwares.Count > 0)
        {
            result.AppendLine($"Software Components:{string.Join(",", this.softwares.Select(s => s.ToString()))}");
        }
        else
        {
            result.AppendLine("Software Components: None");
        }

        return result.ToString().Trim();
    }
}