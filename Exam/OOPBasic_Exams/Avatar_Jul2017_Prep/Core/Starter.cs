using System;
using System.Linq;

public class Starter
{
    private const string EndCommand = "Quit";

    private NationsBuilder nationsBuilder;

    public Starter()
    {
        this.nationsBuilder = new NationsBuilder();
    }

    public void Start()
    {
        string input;
        while ((input = Console.ReadLine()) != EndCommand)
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(tokens.Skip(1).ToList());
                    break;

                case "Monument":
                    this.nationsBuilder.AssignMonument(tokens.Skip(1).ToList());
                    break;

                case "Status":
                    Console.WriteLine(this.nationsBuilder.GetStatus(tokens[1]));
                    break;

                case "War":
                    this.nationsBuilder.IssueWar(tokens[1]);
                    break;
            }
        }

        Console.WriteLine(this.nationsBuilder.GetWarsRecord());
    }
}