using System.Collections.Generic;
using System.Linq;

public class FootballTeam
{
    private string name;
    private List<Player> players;

    public FootballTeam(string name)
    {
        this.name = name;
        this.players = new List<Player>();
    }

    public string Name => this.name;

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public string RemovePlayer(string playerName)
    {
        var player = this.players.FirstOrDefault(p => p.Name.Equals(playerName));
        if (player == null)
        {
            return $"Player {playerName} is not in {this.Name} team.";
        }

        this.players.Remove(player);
        return "OK";
    }

    public double GetRating()
    {
        return this.players.Sum(p => p.GetOverallSkillLevel());
    }
}