using System.Collections.Generic;

public class Garage
{
    private List<Car> parkedCars;

    public Garage()
    {
        this.parkedCars = new List<Car>();
    }

    public void ParkCar(Car car)
    {
        this.parkedCars.Add(car);
    }

    public void UnparkCar(Car car)
    {
        this.parkedCars.Remove(car);
    }

    public bool ContainsCar(Car car)
    {
        if (this.parkedCars.Contains(car))
        {
            return true;
        }

        return false;
    }

    public void TuneCars(int tuneIndex, string addOn)
    {
        foreach (var parkedCar in this.parkedCars)
        {
            parkedCar.GetTuned(tuneIndex, addOn);
        }
    }
}