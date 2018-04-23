using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private int totalLapsNumber;
    private int currentLap;
    private int trackLength;
    private Weather weather;

    private List<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;

    public RaceTower()
    {
        this.racingDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
        this.weather = Weather.Sunny;
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.totalLapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var type = commandArgs[0];
            var name = commandArgs[1];
            var hp = int.Parse(commandArgs[2]);
            var fuelAmount = double.Parse(commandArgs[3]);

            Tyre tyre = CreateTyre(commandArgs);

            var car = new Car(hp, fuelAmount, tyre);
            this.CreateDriver(type, name, car);
        }
        catch
        {
        }
    }

    private void CreateDriver(string type, string name, Car car)
    {
        switch (type)
        {
            case "Aggressive":
                this.racingDrivers.Add(new AggressiveDriver(name, car));
                break;

            case "Endurance":
                this.racingDrivers.Add(new EnduranceDriver(name, car));
                break;
        }
    }

    private static Tyre CreateTyre(List<string> commandArgs)
    {
        var tyreType = commandArgs[4];
        var tyreHardness = double.Parse(commandArgs[5]);

        switch (tyreType)
        {
            case "Hard":
                return new HardTyre(tyreHardness);

            case "Ultrasoft":
                var grip = double.Parse(commandArgs[6]);
                return new UltrasoftTyre(tyreHardness, grip);
        }

        throw new ArgumentException();
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driverName = commandArgs[1];
        var driver = this.racingDrivers.FirstOrDefault(d => d.Name.Equals(driverName));

        if (driver == null)
        {
            return;
        }

        try
        {
            switch (reasonToBox)
            {
                case "ChangeTyres":
                    var tokens = commandArgs.Skip(2).ToList();
                    driver.ChangeTyres(tokens);
                    break;

                case "Refuel":
                    var fuelAmount = double.Parse(commandArgs[2]);
                    driver.Refuel(fuelAmount);
                    break;
            }
        }
        catch
        {
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var lapsToComplete = int.Parse(commandArgs[0]);
        if (lapsToComplete > this.totalLapsNumber - this.currentLap)
        {
            return $"There is no time! On lap {this.currentLap}.";
        }

        var result = new StringBuilder();
        try
        {
            for (int i = 0; i < lapsToComplete; i++)
            {
                this.currentLap++;

                var driversToRemove = new List<Driver>();
                foreach (var driver in this.racingDrivers)
                {
                    driver.CompleteLap(this.trackLength);

                    if (!string.IsNullOrEmpty(driver.FailureReason))
                    {
                        driversToRemove.Add(driver);
                    }
                }

                foreach (var driver in driversToRemove)
                {
                    this.racingDrivers.Remove(driver);
                    this.failedDrivers.Push(driver);
                }

                result.AppendLine(this.Overtake());
            }
        }
        catch
        {
        }

        return result.ToString().Trim();
    }

    private string Overtake()
    {
        var result = new StringBuilder();
        var orderedDrivers = this.racingDrivers.OrderByDescending(d => d.TotalTime).ToList();
        for (int i = 0; i < this.racingDrivers.Count - 1; i++)
        {
            var driverBehind = orderedDrivers[i];
            var driverAhead = orderedDrivers[i + 1];

            var ifOvertakeSuccess = this.TryToOvertake
                (driverBehind, driverAhead);

            if (ifOvertakeSuccess)
            {
                i++;
                result.AppendLine($"{driverBehind.Name} has overtaken {driverAhead.Name} on lap {this.currentLap}.");
            }
        }

        if (this.currentLap.Equals(this.totalLapsNumber))
        {
            result.AppendLine(this.GetWinner());
            return result.ToString().Trim();
        }

        return result.ToString().Trim();
    }

    private bool TryToOvertake(Driver driverBehind, Driver driverAhead)
    {
        var difference = driverBehind.TotalTime - driverAhead.TotalTime;

        var aggressive = driverBehind is AggressiveDriver && driverBehind.Car.Tyre is UltrasoftTyre;

        var endurance = driverBehind is EnduranceDriver && driverBehind.Car.Tyre is HardTyre;

        if ((aggressive || endurance) && difference <= 3)
        {
            if ((aggressive && this.weather.Equals(Weather.Foggy))
                || (endurance && this.weather.Equals(Weather.Rainy)))
            {
                driverBehind.CarCrashes();
                this.racingDrivers.Remove(driverBehind);
                this.failedDrivers.Push(driverBehind);
                return false;
            }

            driverBehind.DecreaseTotalTime(3);
            driverAhead.IncreaseTotalTime(3);
        }
        else if (difference <= 2)
        {
            driverBehind.DecreaseTotalTime(2);
            driverAhead.IncreaseTotalTime(2);
            return true;
        }

        return false;
    }

    public string GetLeaderboard()
    {
        var result = new StringBuilder();
        result.AppendLine($"Lap {this.currentLap}/{this.totalLapsNumber}");

        var position = 1;
        foreach (var driver in this.racingDrivers.OrderBy(d => d.TotalTime))
        {
            result.AppendLine($"{position++} {driver}");
        }

        foreach (var failedDriver in this.failedDrivers)
        {
            result.AppendLine($"{position++} {failedDriver.Name} {failedDriver.FailureReason}");
        }

        return result.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        Weather newWeather;
        var ifParsed = Enum.TryParse(commandArgs[0], out newWeather);
        if (ifParsed)
        {
            this.weather = newWeather;
        }
    }

    private string GetWinner()
    {
        var winner = this.racingDrivers.OrderBy(d => d.TotalTime).First();
        return $"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.";
    }
}