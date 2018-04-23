using System;

public class StartUp
{
    public static void Main()
    {
        var carManager = new CarManager();
        var input = Console.ReadLine().Split();

        while (input[0] != "Cops")
        {
            var number = int.Parse(input[1]);
            switch (input[0])
            {
                case "register":
                    carManager.Register(number, input[2], input[3], input[4], int.Parse(input[5]), int.Parse(input[6]), int.Parse(input[7]), int.Parse(input[8]), int.Parse(input[9]));
                    break;

                case "check":
                    Console.WriteLine(carManager.Check(number));
                    break;

                case "open":
                    if (input.Length == 6)
                    {
                        carManager.Open(number, input[2], int.Parse(input[3]), input[4], int.Parse(input[5]));
                    }
                    else
                    {
                        carManager.OpenSpecial(number, input[2], int.Parse(input[3]), input[4], int.Parse(input[5]),
                            int.Parse(input[6]));
                    }
                    break;

                case "participate":
                    carManager.Participate(number, int.Parse(input[2]));
                    break;

                case "start":
                    Console.WriteLine(carManager.Start(number));
                    break;

                case "park":
                    carManager.Park(number);
                    break;

                case "unpark":
                    carManager.Unpark(number);
                    break;

                case "tune":
                    carManager.Tune(number, input[2]);
                    break;
            }

            input = Console.ReadLine().Split();
        }
    }
}