using System;

namespace PizzaCalories_EXER
{
    public class Dough
    {
        private string flourType;
        private double weight;

        public Dough(string flourType, string backingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BackingTechnique = backingTechnique.ToLower();
            this.Weight = weight;
        }

        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BackingTechnique { get; }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        public double GetDoughCalories()
        {
            var calories = this.Weight * 2;
            calories = this.GetCaloriesForTheFlourType(calories);
            return this.GetCaloriesForTheBackingTechnique(calories);
        }

        private double GetCaloriesForTheBackingTechnique(double totalWeight)
        {
            switch (this.BackingTechnique.ToLower())
            {
                case "crispy":
                    totalWeight *= 0.9;
                    break;

                case "chewy":
                    totalWeight *= 1.1;
                    break;

                case "homemade":
                    totalWeight *= 1;
                    break;
            }

            return totalWeight;
        }

        private double GetCaloriesForTheFlourType(double totalWeight)
        {
            switch (this.FlourType.ToLower())
            {
                case "white":
                    totalWeight *= 1.5;
                    break;

                case "wholegrain":
                    totalWeight *= 1;
                    break;
            }

            return totalWeight;
        }
    }
}