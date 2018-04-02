namespace Google_Exercise
{
    public class Car
    {
        private string carModel;
        public int carSpeed;

        public Car()
        {
        }

        public Car(string carModel, int carSpeed)
        {
            this.carModel = carModel;
            this.carSpeed = carSpeed;
        }

        public string CarModel => this.carModel;
    }
}