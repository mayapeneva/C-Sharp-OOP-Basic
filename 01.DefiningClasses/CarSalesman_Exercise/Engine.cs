namespace CarSalesman_Exercise
{
    public class Engine
    {
        public string model;
        public int power;
        public int displacement;
        public string efficiency;

        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
            this.efficiency = "n/a";
        }

        public int Displacement => this.displacement;
        public string Efficiency => this.efficiency;
    }
}
