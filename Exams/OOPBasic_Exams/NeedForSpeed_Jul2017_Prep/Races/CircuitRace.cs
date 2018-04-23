using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    public CircuitRace(int length, string route, int prizePool, int laps) : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps { get; }

    public override void CalculatePerformancePoints(Car car)
    {
        car.Durability -= this.Laps * (Length * Length);
        car.PerformancePoints = (car.Horsepower / car.Acceleration) + (car.Suspension + car.Durability);
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
            var moneyWon = this.PrizePool * 40 / 100;
            var counter = 0;
            result.AppendLine($"{this.Route} - {this.Length * this.Laps}");
            foreach (var car in this.Participants.OrderByDescending(c => c.PerformancePoints).Take(4))
            {
                if (counter == 1)
                {
                    moneyWon = this.PrizePool * 30 / 100;
                }
                else if (counter == 2)
                {
                    moneyWon = this.PrizePool * 20 / 100;
                }
                else if (counter == 3)
                {
                    moneyWon = this.PrizePool * 10 / 100;
                }

                result.AppendLine($"{counter + 1}. {car.Brand} {car.Model} {car.PerformancePoints}PP - ${moneyWon}");
                counter++;
            }
        }

        return result.ToString().Trim();
    }
}