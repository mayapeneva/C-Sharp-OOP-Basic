using System.Collections.Generic;

namespace RawData_Exercise
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;

        public Car(string model)
        {
            this.model = model;
            this.engine = new Engine();
            this.cargo = new Cargo();
            this.tires = new List<Tire>();
        }

        public string Model => this.model;
        public Engine Engine => this.engine;
        public Cargo Cargo => this.cargo;
        public List<Tire> Tires => this.tires;
    }
}
