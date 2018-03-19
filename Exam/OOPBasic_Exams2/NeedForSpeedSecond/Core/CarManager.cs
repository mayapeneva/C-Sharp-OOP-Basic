using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    private CarFactory carFactory;
    private RaceFactory raceFactory;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
        this.carFactory = new CarFactory();
        this.raceFactory = new RaceFactory();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        this.cars.Add(id, this.carFactory.CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
    }

    public string Check(int id)
    {
        return this.cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        this.races.Add(id, this.raceFactory.CreateRace(type, length, route, prizePool));
    }

    public void Participate(int carId, int raceId)
    {
        var car = this.cars[carId];
        if (!this.garage.ContainsCar(car))
        {
            this.races[raceId].AddCar(car);
        }
    }

    public string Start(int id)
    {
        var race = this.races[id];
        var result = race.Start();
        if (result.Split()[0] != "Cannot")
        {
            this.races.Remove(id);
        }
        return result;
    }

    public void Park(int id)
    {
        var car = this.cars[id];
        if (!this.races.Any(r => r.Value.ContainsCar(car)))
        {
            this.garage.ParkCar(car);
        }
    }

    public void Unpark(int id)
    {
        this.garage.UnparkCar(this.cars[id]);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        this.garage.TuneCars(tuneIndex, addOn);
    }
}