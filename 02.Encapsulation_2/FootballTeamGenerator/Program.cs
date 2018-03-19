using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var teams = new List<FootballTeam>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(';');
            var teamName = tokens[1];
            switch (tokens[0])
            {
                case "Team":
                    if (string.IsNullOrWhiteSpace(teamName) || string.IsNullOrEmpty(teamName))
                    {
                        Console.WriteLine("A name should not be empty.");
                        break;
                    }

                    teams.Add(new FootballTeam(teamName));
                    break;

                case "Add":
                    var team = teams.FirstOrDefault(t => t.Name.Equals(teamName));
                    if (team == null)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        break;
                    }

                    var playerName = tokens[2];
                    if (string.IsNullOrWhiteSpace(playerName) || string.IsNullOrEmpty(playerName))
                    {
                        Console.WriteLine("A name should not be empty.");
                        break;
                    }

                    var player = new Player(playerName);
                    var successs = player.AddStats(double.Parse(tokens[3]), double.Parse(tokens[4]), double.Parse(tokens[5]), double.Parse(tokens[6]), double.Parse(tokens[7]));
                    if (successs != "OK")
                    {
                        Console.WriteLine(successs);
                        break;
                    }

                    team.AddPlayer(player);
                    break;

                case "Remove":
                    team = teams.FirstOrDefault(t => t.Name.Equals(teamName));
                    if (team == null)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        break;
                    }

                    var success = team.RemovePlayer(tokens[2]);
                    if (success != "OK")
                    {
                        Console.WriteLine(success);
                    }
                    break;

                case "Rating":
                    team = teams.FirstOrDefault(t => t.Name.Equals(teamName));
                    if (team == null)
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                        break;
                    }

                    Console.WriteLine($"{teamName} - {team.GetRating():f0}");
                    break;
            }
        }
    }
}