using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator_EXER
{
    public class Player
    {
        private string name;
        private List<int> stats;

        public Player(string name, List<int> stats)
        {
            this.Name = name;
            this.stats = stats;
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

        private List<int> Stats => this.stats;

        public double GetPlayersSkillLevel()
        {
            return this.Stats.Average();
        }
    }
}