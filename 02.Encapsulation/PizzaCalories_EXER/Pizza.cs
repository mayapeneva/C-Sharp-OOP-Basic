using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories_EXER
{
    public class Pizza
    {
        private string name;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public List<Topping> Toppings { get; }

        public void AddTopping(Topping topping)
        {
            this.Toppings.Add(topping);
        }

        public double GetAllCalories()
        {
            return this.Dough.GetDoughCalories() + this.Toppings.Sum(t => t.GetToppingCalories());
        }
    }
}