using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        if (type == "Performance")
        {
            this.cars.Add(id, new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
        }
        else if (type == "Show")
        {
            this.cars.Add(id, new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
        }
    }

    public string Check(int id)
    {
        return this.cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                this.races.Add(id, new CasualRace(length, route, prizePool));
                break;

            case "Drag":
                this.races.Add(id, new DragRace(length, route, prizePool));
                break;

            case "Drift":
                this.races.Add(id, new DriftRace(length, route, prizePool));
                break;
        }
    }

    public void OpenSpecial(int id, string type, int length, string route, int prizePool, int goldTimeOrLaps)
    {
        switch (type)
        {
            case "TimeLimit":
                this.races.Add(id, new TimeLimitRace(length, route, prizePool, goldTimeOrLaps));
                break;

            case "Circuit":
                this.races.Add(id, new CircuitRace(length, route, prizePool, goldTimeOrLaps));
                break;
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!this.garage.ParkedCars.ContainsKey(carId) && this.cars.ContainsKey(carId) && this.races.ContainsKey(raceId))
        {
            this.races[raceId].AddCarInTheRace(cars[carId]);
        }
    }

    public string Start(int id)
    {
        var race = this.races[id];
        if (race.Participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        for (int i = 0; i < race.Participants.Count; i++)
        {
            race.CalculatePerformancePoints(race.Participants[i]);
        }

        race = this.races[id];
        races.Remove(id);
        return race.ToString();
    }

    public void Park(int id)
    {
        var model = cars[id].Model;
        var brand = cars[id].Brand;
        if (!races.Values.Any(p => p.Participants.Any(c => c.Model == model && c.Brand == brand)))
        {
            this.garage.ParkCarInTheGarage(id, cars[id]);
        }
    }

    public void Unpark(int id)
    {
        this.garage.UnparkCarFromTheGarage(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (garage.ParkedCars.Count > 0)
        {
            foreach (var car in garage.ParkedCars)
            {
                car.Value.IncreaseParameters(tuneIndex, addOn);
            }
        }
    }
}