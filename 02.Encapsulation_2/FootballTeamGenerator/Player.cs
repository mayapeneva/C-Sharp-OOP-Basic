using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private List<double> stats;

    public Player(string name)
    {
        this.name = name;
        this.stats = new List<double>();
    }

    public string Name => this.name;

    public string AddStats(params double[] parameters)
    {
        for (int i = 0; i < parameters.Length; i++)
        {
            if (parameters[i] < 0 || parameters[i] > 100)
            {
                var stat = string.Empty;
                switch (i)
                {
                    case 0:
                        stat = "Endurance";
                        break;

                    case 1:
                        stat = "Sprint";
                        break;

                    case 2:
                        stat = "Dribble";
                        break;

                    case 3:
                        stat = "Passing";
                        break;

                    case 4:
                        stat = "Shooting";
                        break;
                }
                return $"{stat} should be between 0 and 100.";
            }

            this.stats.Add(parameters[i]);
        }

        return "OK";
    }

    public double GetOverallSkillLevel()
    {
        return this.stats.Average();
    }
}