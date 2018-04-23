using System;
using System.Linq;

public class Engine
{
    private readonly RaceTower raceTower;

    public Engine()
    {
        this.raceTower = new RaceTower();
    }

    public void Start()
    {
        var lapsNumber = int.Parse(Console.ReadLine());
        var trackLength = int.Parse(Console.ReadLine());
        this.raceTower.SetTrackInfo(lapsNumber, trackLength);

        while (lapsNumber > 0)
        {
            var input = Console.ReadLine().Split();
            lapsNumber = this.ExecuteCommand(lapsNumber, input);
        }
    }

    private int ExecuteCommand(int lapsNumber, string[] input)
    {
        var command = input[0];
        var args = input.Skip(1).ToList();
        switch (command)
        {
            case "RegisterDriver":
                this.raceTower.RegisterDriver(args);
                break;

            case "Leaderboard":
                Console.WriteLine(this.raceTower.GetLeaderboard());
                break;

            case "CompleteLaps":

                var lapsToGo = int.Parse(args[0]);

                if (lapsToGo <= lapsNumber)
                {
                    lapsNumber -= lapsToGo;
                }

                var result = this.raceTower.CompleteLaps(args);
                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }
                break;

            case "Box":
                this.raceTower.DriverBoxes(args);
                break;

            case "ChangeWeather":
                this.raceTower.ChangeWeather(args);
                break;
        }

        return lapsNumber;
    }
}