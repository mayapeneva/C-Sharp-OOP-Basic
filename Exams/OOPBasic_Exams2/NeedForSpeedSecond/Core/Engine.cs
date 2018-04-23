using System;

public class Engine
{
    private const string QuitMessage = "Cops Are Here";

    private CarManager carManager;

    public Engine(CarManager carManager)
    {
        this.carManager = carManager;
    }

    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != QuitMessage)
        {
            var data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = data[0];
            var id = int.Parse(data[1]);
            switch (command)
            {
                case "register":
                    this.carManager.Register(id, data[2], data[3], data[4], int.Parse(data[5]), int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8]), int.Parse(data[9]));
                    break;

                case "check":
                    Console.WriteLine(this.carManager.Check(id));
                    break;

                case "open":
                    this.carManager.Open(id, data[2], int.Parse(data[3]), data[4], int.Parse(data[5]));
                    break;

                case "participate":
                    this.carManager.Participate(id, int.Parse(data[2]));
                    break;

                case "start":
                    Console.WriteLine(this.carManager.Start(id));
                    break;

                case "park":
                    this.carManager.Park(id);
                    break;

                case "unpark":
                    this.carManager.Unpark(id);
                    break;

                case "tune":
                    this.carManager.Tune(id, data[2]);
                    break;
            }
        }
    }
}