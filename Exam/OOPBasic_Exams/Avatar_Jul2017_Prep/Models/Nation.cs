using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private string type;
    private List<Benders> benders;
    private List<Monuments> monuments;

    public Nation(string type)
    {
        this.type = type;
        this.benders = new List<Benders>();
        this.monuments = new List<Monuments>();
    }

    public double NationalTotalPower
    {
        get
        {
            var result = this.benders.Sum(b => b.TotalPower);
            return result + (result * this.monuments.Sum(m => m.Affinity) / 100);
        }
    }

    public void AddBender(Benders bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonument(Monuments monument)
    {
        this.monuments.Add(monument);
    }

    public void RemoveAllBendersAndMonuments()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine($"{this.type} Nation");
        if (this.benders.Count > 0)
        {
            result.AppendLine("Benders:");
            foreach (var bender in this.benders)
            {
                result.AppendLine($"###{this.type} Bender: " + bender);
            }
        }
        else
        {
            result.AppendLine("Benders: None");
        }

        if (this.monuments.Count > 0)
        {
            result.AppendLine("Monuments:");
            foreach (var monument in this.monuments)
            {
                result.AppendLine($"###{this.type} Monument: " + monument);
            }
        }
        else
        {
            result.AppendLine("Monuments: None");
        }

        return result.ToString().Trim();
    }
}