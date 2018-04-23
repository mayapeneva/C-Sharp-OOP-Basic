using System.Collections.Generic;

public class Garage
{
    public Garage()
    {
        this.ParkedCars = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> ParkedCars { get; }

    public void ParkCarInTheGarage(int id, Car car)
    {
        ParkedCars.Add(id, car);
    }

    public void UnparkCarFromTheGarage(int id)
    {
        ParkedCars.Remove(id);
    }
}