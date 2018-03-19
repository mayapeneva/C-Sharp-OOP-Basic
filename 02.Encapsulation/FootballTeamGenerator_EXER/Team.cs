using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator_EXER
{
    public class Team
    {
        private string name;
        private double rating;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double Rating
        {
            get { return this.rating; }
            private set { this.rating = value; }
        }

        private List<Player> Players => this.players;

        public double GetTeamsRating()
        {
            if (this.Players.Count > 0)
            {
                var rateAverage = this.Players.Average(p => p.GetPlayersSkillLevel());
                return Math.Round(rateAverage);
            }
            else
            {
                return 0;
            }
        }

        public void AddAPlayer(string newName, List<int> stats)
        {
            this.Players.Add(new Player(newName, stats));
        }

        public void RemoveAPlayer(string removeName)
        {
            if (this.Players.Any(p => p.Name == removeName))
            {
                this.Players.RemoveAll(p => p.Name == removeName);
            }
            else
            {
                throw new ArgumentException($"Player {removeName} is not in {this.Name} team.");
            }
        }
    }
}