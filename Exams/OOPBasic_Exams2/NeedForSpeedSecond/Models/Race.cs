using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private readonly List<Car> participants;

    protected Race(int length, string route, int prizePool)
    {
        this.length = length;
        this.route = route;
        this.prizePool = prizePool;
        this.participants = new List<Car>();
    }

    public void AddCar(Car car)
    {
        this.participants.Add(car);
    }

    public bool ContainsCar(Car car)
    {
        if (this.participants.Contains(car))
        {
            return true;
        }

        return false;
    }

    public string Start()
    {
        if (this.participants.Count == 0)
        {
            return "Cannot start the race with zero participants.";
        }

        var result = this.GetWinners();

        return $"{this.route} - {this.length}" + Environment.NewLine + result;
    }

    private string GetWinners()
    {
        var result = new StringBuilder();

        var place = 1;
        this.participants.ForEach(p => this.CalculatePerformancePoints(p));

        foreach (var participant in this.participants.OrderByDescending(p => p.PerformancePoints))
        {
            if (place == 4)
            {
                break;
            }

            int moneyWon;
            if (place == 1)
            {
                moneyWon = this.prizePool * 1 / 2;
            }
            else if (place == 2)
            {
                moneyWon = this.prizePool * 3 / 10;
            }
            else
            {
                moneyWon = this.prizePool * 1 / 5;
            }

            result.AppendLine($"{place}. {participant.Brand} {participant.Model} {participant.PerformancePoints}PP - ${moneyWon}");
            place++;
        }

        return result.ToString().Trim();
    }

    protected abstract void CalculatePerformancePoints(Car participant);
}