using System;
using System.Text;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool, int goldTime) : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime { get; }

    public override void AddCarInTheRace(Car car)
    {
        if (this.Participants.Count < 1)
        {
            this.Participants.Add(car);
        }
    }

    public override void CalculatePerformancePoints(Car car)
    {
        car.PerformancePoints = this.Length * ((car.Horsepower / 100) * car.Acceleration);
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        if (this.Participants.Count == 0)
        {
            result.AppendLine("Cannot start the race with zero participants.");
        }
        else
        {
            var prizeWon = this.PrizePool;
            var car = this.Participants[0];
            var timeEarned = string.Empty;
            if (car.PerformancePoints <= this.GoldTime)
            {
                timeEarned = "Gold";
            }
            else if (car.PerformancePoints <= this.GoldTime + 15)
            {
                timeEarned = "Silver";
                prizeWon = (int)Math.Round(prizeWon * 0.5);
            }
            else
            {
                timeEarned = "Bronze";
                prizeWon = (int)Math.Round(prizeWon * 0.3);
            }

            result.AppendLine($"{this.Route} - {this.Length}");
            result.AppendLine($"{car.Brand} {car.Model} - {car.PerformancePoints} s.");
            result.AppendLine($"{timeEarned} Time, ${prizeWon}.");
        }

        return result.ToString();
    }
}