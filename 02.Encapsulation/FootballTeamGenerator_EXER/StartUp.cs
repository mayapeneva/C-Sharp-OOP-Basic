using System;
using System.Collections.Generic;

namespace FootballTeamGenerator_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var teams = new Dictionary<string, Team>();

            try
            {
                var input = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                while (input[0] != "END")
                {
                    var teamName = input[1];
                    switch (input[0])
                    {
                        case "Team":
                            teams[teamName] = new Team(teamName);
                            break;

                        case "Add":
                            AddPlayerInATeam(teams, input, teamName);
                            break;

                        case "Remove":
                            teams[teamName].RemoveAPlayer(input[2]);
                            break;

                        case "Rating":
                            GetRatingForTheTeam(teams, teamName);
                            break;
                    }

                    input = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AddPlayerInATeam(Dictionary<string, Team> teams, string[] input, string teamName)
        {
            if (teams.ContainsKey(teamName))
            {
                var playerStat = new List<int>();
                for (int i = 3; i < input.Length; i++)
                {
                    //THIS CHECK SHOULD BE DONE WITHIN THE CLASS!!!
                    if (int.Parse(input[i]) >= 0 && int.Parse(input[i]) <= 100)
                    {
                        playerStat.Add(int.Parse(input[i]));
                    }
                    else
                    {
                        Console.WriteLine("Endurance should be between 0 and 100.");
                        break;
                    }
                }
                teams[teamName].AddAPlayer(input[2], playerStat);
            }
            else
            {
                Console.WriteLine($"Team {teamName} does not exist.");
            }
        }

        private static void GetRatingForTheTeam(Dictionary<string, Team> teams, string teamName)
        {
            if (teams.ContainsKey(teamName))
            {
                Console.WriteLine($"{teamName} - {teams[teamName].GetTeamsRating():f0}");
            }
            else
            {
                Console.WriteLine($"Team {teamName} does not exist.");
            }
        }
    }
}