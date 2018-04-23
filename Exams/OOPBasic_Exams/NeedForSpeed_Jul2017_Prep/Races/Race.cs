using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
    }

    public int Length { get; }
    public string Route { get; }
    public int PrizePool { get; }
    public List<Car> Participants { get; }

    public virtual void AddCarInTheRace(Car car)
    {
        Participants.Add(car);
    }

    public abstract void CalculatePerformancePoints(Car car);

    public override string ToString()
    {
        var result = new StringBuilder();
        if (this.Participants.Count == 0)
        {
            result.AppendLine("Cannot start the race with zero participants.");
        }
        else
        {
            var moneyWon = this.PrizePool / 2;
            var counter = 0;
            result.AppendLine($"{this.Route} - {this.Length}");
            foreach (var car in this.Participants.OrderByDescending(c => c.PerformancePoints).Take(3))
            {
                if (counter == 1)
                {
                    moneyWon = this.PrizePool * 30 / 100;
                }
                else if (counter == 2)
                {
                    moneyWon = this.PrizePool * 20 / 100;
                }

                result.AppendLine($"{counter + 1}. {car.Brand} {car.Model} {car.PerformancePoints}PP - ${moneyWon}");
                counter++;
            }
        }

        return result.ToString().Trim();
    }
}