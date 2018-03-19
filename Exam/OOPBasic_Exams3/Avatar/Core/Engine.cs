using System;
using System.Linq;

public class Engine
{
    private NationsBuilder nationsBuilder;

    public Engine()
    {
        this.nationsBuilder = new NationsBuilder();
    }

    public void Start()
    {
        while (true)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.None);
            var command = input[0];
            var commandArgs = input.Skip(1).ToList();
            switch (command)
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(commandArgs);
                    break;

                case "Monument":
                    this.nationsBuilder.AssignMonument(commandArgs);
                    break;

                case "Status":
                    Console.WriteLine(this.nationsBuilder.GetStatus(commandArgs[0]));
                    break;

                case "War":
                    this.nationsBuilder.IssueWar(commandArgs[0]);
                    break;

                case "Quit":
                    Console.WriteLine(this.nationsBuilder.GetWarsRecord());
                    return;
            }
        }
    }
}