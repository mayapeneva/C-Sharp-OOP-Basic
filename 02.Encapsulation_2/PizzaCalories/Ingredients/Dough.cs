using System;

public class Dough
{
    private string flourType;
    private string bakinngTechnique;
    private double weight;

    public Dough(string flourType, string bakinngTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakinngTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get { return this.flourType; }
        set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        get { return this.bakinngTechnique; }
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakinngTechnique = value;
        }
    }

    public double Weight
    {
        get { return this.weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            this.weight = value;
        }
    }

    public double GetCalories()
    {
        return ((this.weight * 2) * this.GetFlourTypeModifier()) * this.GetBackingTechniqueModifier();
    }

    private double GetBackingTechniqueModifier()
    {
        switch (this.BakingTechnique.ToLower())
        {
            case "crispy":
                return 0.9;

            case "chewy":
                return 1.1;

            case "homemade":
                return 1;

            default:
                return 1;
        }
    }

    private double GetFlourTypeModifier()
    {
        switch (this.FlourType.ToLower())
        {
            case "white":
                return 1.5;

            case "wholegrain":
                return 1;

            default:
                return 1;
        }
    }
}