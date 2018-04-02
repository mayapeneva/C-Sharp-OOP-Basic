using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, List<Bender>> benders;
    private Dictionary<string, List<Monument>> monuments;
    private Queue<string> wars;

    public NationsBuilder()
    {
        this.benders = new Dictionary<string, List<Bender>>();
        this.monuments = new Dictionary<string, List<Monument>>();
        this.wars = new Queue<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var bender = this.CreateBender(benderArgs);

        if (bender != null)
        {
            if (!this.benders.ContainsKey(type))
            {
                this.benders[type] = new List<Bender>();
            }

            this.benders[type].Add(bender);
        }
    }

    private Bender CreateBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var specificParam = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, specificParam);

            case "Water":
                return new WaterBender(name, power, specificParam);

            case "Fire":
                return new FireBender(name, power, specificParam);

            case "Earth":
                return new EarthBender(name, power, specificParam);
        }

        return null;
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var monument = this.CreateMonument(monumentArgs);

        if (monument != null)
        {
            if (!this.monuments.ContainsKey(type))
            {
                this.monuments[type] = new List<Monument>();
            }

            this.monuments[type].Add(monument);
        }
    }

    private Monument CreateMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                return new AirMonument(name, affinity);

            case "Water":
                return new WaterMonument(name, affinity);

            case "Fire":
                return new FireMonument(name, affinity);

            case "Earth":
                return new EarthMonument(name, affinity);
        }

        return null;
    }

    public string GetStatus(string nationsType)
    {
        var result = new StringBuilder();
        result.AppendLine($"{nationsType} Nation");
        if (this.benders.ContainsKey(nationsType) && this.benders[nationsType].Count > 0)
        {
            result.AppendLine("Benders:");
            foreach (var bender in this.benders[nationsType])
            {
                result.AppendLine($"###{nationsType} Bender: " + bender);
            }
        }
        else
        {
            result.AppendLine("Benders: None");
        }

        if (this.monuments.ContainsKey(nationsType) && this.monuments[nationsType].Count > 0)
        {
            result.AppendLine("Monuments:");
            foreach (var monument in this.monuments[nationsType])
            {
                result.AppendLine($"###{nationsType} Monument: " + monument);
            }
        }
        else
        {
            result.AppendLine("Monuments: None");
        }

        return result.ToString().Trim();
    }

    public void IssueWar(string nationsType)
    {
        this.wars.Enqueue(nationsType);

        if (!this.benders.ContainsKey(nationsType) || this.benders.Count == 0)
        {
            return;
        }

        var totalPower = new Dictionary<string, double>();
        foreach (var kvp in this.benders)
        {
            var bendersPower = kvp.Value.Sum(b => b.CalculateTotalPower());
            if (this.monuments.ContainsKey(kvp.Key))
            {
                var monumentPower = this.monuments[kvp.Key].Sum(m => m.IncreaseTotalPower());
                totalPower[kvp.Key] = bendersPower * monumentPower;
            }
            else
            {
                totalPower[kvp.Key] = bendersPower;
            }
        }

        var winnerNation = totalPower.OrderByDescending(a => a.Value).First().Key;

        foreach (var kvpBender in this.benders)
        {
            if (kvpBender.Key != winnerNation)
            {
                kvpBender.Value.Clear();
            }
        }

        foreach (var kvpMonument in this.monuments)
        {
            if (kvpMonument.Key != winnerNation)
            {
                kvpMonument.Value.Clear();
            }
        }
    }

    public string GetWarsRecord()
    {
        var result = new StringBuilder();
        var number = 1;
        while (this.wars.Count > 0)
        {
            result.AppendLine($"War {number++} issued by {this.wars.Dequeue()}");
        }

        return result.ToString();
    }
}