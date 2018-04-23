using System;
using System.Linq;

public class Engine
{
    private readonly RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    public void Run()
    {
        var numberOfLaps = int.Parse(Console.ReadLine());
        var trackLength = int.Parse(Console.ReadLine());
        this.raceTower.SetTrackInfo(numberOfLaps, trackLength);

        for (int i = 0; i < numberOfLaps; i++)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            this.ExecuteCommand(input);
        }
    }

    private void ExecuteCommand(string[] input)
    {
        var command = input[0];
        var data = input.Skip(1).ToList();

        try
        {
            switch (command)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(data);
                    break;

                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;

                case "CompleteLaps":
                    var result = this.raceTower.CompleteLaps(data);
                    if (result != string.Empty)
                    {
                        Console.WriteLine(result);
                    }
                    break;

                case "Box":
                    this.raceTower.DriverBoxes(data);
                    break;

                case "ChangeWeather":
                    this.raceTower.ChangeWeather(data);
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}