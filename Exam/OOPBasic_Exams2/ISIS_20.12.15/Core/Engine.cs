using System;
using System.Linq;

public class Engine
{
    private readonly HackersManager hackersManager;
    private bool IsApocalypse;
    private int days;

    public Engine(HackersManager hackersManager)
    {
        this.hackersManager = hackersManager;
    }

    public void Run()
    {
        while (!this.IsApocalypse)
        {
            this.hackersManager.CheckForDailyLosses();

            var input = Console.ReadLine().Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            var name = input[0];

            var data = input[1].Trim(')').Split(new[] { '(' }, StringSplitOptions.RemoveEmptyEntries);
            var command = data[0];

            var parameters = data.Length > 1 ? data[1].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList() : null;

            switch (command)
            {
                case "create":
                    this.hackersManager.CreateGroup(name, parameters);
                    break;

                case "attack":
                    this.hackersManager.Attack(name, parameters[0]);
                    break;

                case "akbar":
                    break;

                case "status":
                    Console.WriteLine(this.hackersManager.Status());
                    break;

                case "apocalypse":

                    this.IsApocalypse = true;
                    break;
            }

            this.days++;
        }
    }
}