using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;
    private bool IsShutDown;

    public Engine(DraftManager draftManager)
    {
        this.draftManager = draftManager;
    }

    public void Run()
    {
        var result = string.Empty;
        while (!this.IsShutDown)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = input[0];
            var data = input.Skip(1).ToList();
            switch (command)
            {
                case "RegisterHarvester":
                    result = this.draftManager.RegisterHarvester(data);
                    break;

                case "RegisterProvider":
                    result = this.draftManager.RegisterProvider(data);
                    break;

                case "Day":
                    result = this.draftManager.Day();
                    break;

                case "Mode":
                    result = this.draftManager.Mode(data);
                    break;

                case "Check":
                    result = this.draftManager.Check(data);
                    break;

                case "Shutdown":
                    result = this.draftManager.ShutDown();
                    this.IsShutDown = true;
                    break;
            }

            Console.WriteLine(result);
        }
    }
}