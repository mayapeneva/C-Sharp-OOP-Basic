using System.Collections.Generic;
using System.Linq;

namespace CarSalesman_Exercise
{
    public class Car
    {
        public string model;
        public string engineModel;
        public int weight;
        public string color;

        public Car(string model, string engineModel)
        {
            this.model = model;
            this.engineModel = engineModel;
            this.color = "n/a";
        }

        public int Weight => this.weight;
        public string Color => this.color;

        public Engine GetEngine(List<Engine> engines)
        {
            return engines.FirstOrDefault(e => e.model == engineModel);
        }
    }
}
