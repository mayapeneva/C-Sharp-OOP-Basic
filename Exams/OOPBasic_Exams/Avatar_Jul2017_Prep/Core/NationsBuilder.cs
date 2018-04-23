using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> warsRecord;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>();
        this.warsRecord = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var secondParam = double.Parse(benderArgs[3]);
        switch (type)
        {
            case "Air":
                var airBender = new AirBender(name, power, secondParam);
                this.AddBenderToNation(type, airBender);
                break;

            case "Earth":
                var earthBender = new EarthBender(name, power, secondParam);
                this.AddBenderToNation(type, earthBender);
                break;

            case "Fire":
                var fireBender = new FireBender(name, power, secondParam);
                this.AddBenderToNation(type, fireBender);
                break;

            case "Water":
                var waterBender = new WaterBender(name, power, secondParam);
                this.AddBenderToNation(type, waterBender);
                break;
        }
    }

    private void AddBenderToNation(string type, Benders bender)
    {
        if (!this.nations.ContainsKey(type))
        {
            this.nations[type] = new Nation(type);
        }

        this.nations[type].AddBender(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1]; ;
        var affinity = int.Parse(monumentArgs[2]);
        switch (type)
        {
            case "Air":
                var airMonument = new AirMonument(name, affinity);
                this.AddMonumentToNation(type, airMonument);
                break;

            case "Earth":
                var earthMonument = new EarthMonument(name, affinity);
                this.AddMonumentToNation(type, earthMonument);
                break;

            case "Fire":
                var fireMonument = new FireMonument(name, affinity);
                this.AddMonumentToNation(type, fireMonument);
                break;

            case "Water":
                var waterMonument = new WaterMonument(name, affinity);
                this.AddMonumentToNation(type, waterMonument);
                break;
        }
    }

    private void AddMonumentToNation(string type, Monuments monument)
    {
        if (!this.nations.ContainsKey(type))
        {
            this.nations[type] = new Nation(type);
        }

        this.nations[type].AddMonument(monument);
    }

    public string GetStatus(string nationsType)
    {
        return this.nations[nationsType].ToString();
    }

    public void IssueWar(string nationsType)
    {
        this.warsRecord.Add(nationsType);
        if (this.nations.Count > 0)
        {
            var maxTotalPower = this.nations.Values.Select(n => n.NationalTotalPower).Max();
            foreach (var nation in this.nations.Values.Where(n => !Math.Round(n.NationalTotalPower).Equals(Math.Round(maxTotalPower))))
            {
                nation.RemoveAllBendersAndMonuments();
            }
        }
    }

    public string GetWarsRecord()
    {
        var result = new StringBuilder();
        for (int i = 0; i < this.warsRecord.Count; i++)
        {
            result.AppendLine($"War {i + 1} issued by {this.warsRecord[i]}");
        }

        return result.ToString().Trim();
    }
}