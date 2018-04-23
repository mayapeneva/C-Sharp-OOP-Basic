using System;
using System.Linq;

public class Engine
{
    private readonly DraftManager draftManager;
    private bool readyToShutDown;

    public Engine()
    {
        this.draftManager = new DraftManager(new HarvesterFactory(), new ProviderFactory());
    }

    public void Run()
    {
        while (!this.readyToShutDown)
        {
            var input = Console.ReadLine();
            var datatokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = datatokens[0];
            var paramsToPass = datatokens.Skip(1).ToList();

            var result = string.Empty;
            switch (command)
            {
                case "RegisterHarvester":
                    result = this.draftManager.RegisterHarvester(paramsToPass);
                    break;

                case "RegisterProvider":
                    result = this.draftManager.RegisterProvider(paramsToPass);
                    break;

                case "Day":
                    result = this.draftManager.Day();
                    break;

                case "Mode":
                    result = this.draftManager.Mode(paramsToPass);
                    break;

                case "Check":
                    result = this.draftManager.Check(paramsToPass);
                    break;

                case "Shutdown":
                    result = this.draftManager.ShutDown();
                    this.readyToShutDown = true;
                    break;
            }

            Console.WriteLine(result);
        }
    }
}