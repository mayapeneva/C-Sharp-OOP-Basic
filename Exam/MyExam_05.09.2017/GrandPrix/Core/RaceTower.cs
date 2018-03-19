using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private List<Driver> race;

    private int totalLapsNumber;
    private int trackLength;
    private int currentLap;
    private string weather;

    public RaceTower()
    {
        this.race = new List<Driver>();
        this.weather = "Sunny";
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.totalLapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        this.race.Add(this.CreateDriver(commandArgs));
    }

    private Driver CreateDriver(List<string> args)
    {
        var type = args[0];
        var name = args[1];
        var hp = int.Parse(args[2]);
        var fuelAmount = double.Parse(args[3]);
        var tyreArgs = args.Skip(4).ToList();

        var tyre = this.CreateTyre(tyreArgs);

        var car = new Car(hp, fuelAmount, tyre);

        if (type.Equals("Aggressive"))
        {
            return new AggressiveDriver(name, car);
        }

        return new EnduranceDriver(name, car);
    }

    private Tyre CreateTyre(List<string> tyreArgs)
    {
        var tyreType = tyreArgs[0];
        var tyreHardness = double.Parse(tyreArgs[1]);
        if (tyreType.Equals("Hard"))
        {
            return new HardTyre(tyreHardness);
        }

        var grip = double.Parse(tyreArgs[2]);
        return new UltrasoftTyre(tyreHardness, grip);
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driversName = commandArgs[1];
        var driver = this.race.FirstOrDefault(d => d.Name.Equals(driversName));
        if (driver != null)
        {
            driver.Box();

            if (reasonToBox.Equals("Refuel"))
            {
                var fuelQuantity = double.Parse(commandArgs[2]);
                driver.Car.Refuel(fuelQuantity);
            }
            else
            {
                var tyreParams = commandArgs.Skip(2).ToList();
                var tyre = this.CreateTyre(tyreParams);
                driver.Car.ChangeTyres(tyre);
            }
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var lapsToComplete = int.Parse(commandArgs[0]);
        if (lapsToComplete > this.totalLapsNumber - this.currentLap)
        {
            throw new ArgumentException($"There is no time! On lap {this.currentLap}.");
        }

        var result = new StringBuilder();
        var racers = this.race.Where(d => d.CanRace).ToList();
        for (int i = 0; i < lapsToComplete; i++)
        {
            this.currentLap++;
            foreach (Driver driver in racers)
            {
                driver.ChangeTime(this.trackLength);
                driver.Car.ReduceFuel(this.trackLength * driver.FuelConsumptionPerKm);
                driver.Car.DegradateTyre();
            }

            var orderedRace = racers.OrderBy(d => d.TotalTime).ToList();
            for (int j = 1; j < orderedRace.Count; j++)
            {
                if (orderedRace[j].TotalTime - orderedRace[j - 1].TotalTime <= 0.02)
                {
                    orderedRace[j - 1].Overtake(this.weather);
                    orderedRace[j].GetOvertaken(this.weather);
                    result.AppendLine($"{orderedRace[j - 1].Name} has overtaken {orderedRace[j].Name} on lap {this.currentLap}");
                }
            }
        }

        var winner = this.race.OrderByDescending(d => d.TotalTime).First();
        result.AppendLine($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.");
        return result.ToString().Trim();
    }

    public string GetLeaderboard()
    {
        var result = new StringBuilder();
        result.AppendLine($"Lap {this.currentLap}/{this.totalLapsNumber}");

        var position = 1;
        foreach (Driver driver in this.race.Where(d => d.CanRace).OrderBy(d => d.TotalTime))
        {
            result.AppendLine($"{position} {driver.Name} {driver.TotalTime:f3}");
            position++;
        }

        foreach (Driver driver in this.race.Where(d => !d.CanRace))
        {
            result.AppendLine($"{position} {driver.Name} {driver.Status}");
            position++;
        }

        return result.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }
}