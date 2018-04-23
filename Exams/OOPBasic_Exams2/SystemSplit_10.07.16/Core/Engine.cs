using System;

public class Engine
{
    private SystemManager systemManager;
    private DumpManager dumpManager;
    private ConsoleReader reader;
    private ConsoleWriter writer;
    private bool isSystemSplit;

    public Engine(SystemManager systemManager, DumpManager dumpManager, ConsoleReader reader, ConsoleWriter writer)
    {
        this.systemManager = systemManager;
        this.dumpManager = dumpManager;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (!this.isSystemSplit)
        {
            var input = this.reader.ReadLine().Trim(')').Split(new[] { '(' }, StringSplitOptions.RemoveEmptyEntries);
            var data = input.Length > 1 ? input[1].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries) : null;

            switch (input[0])
            {
                case "RegisterPowerHardware":
                    this.systemManager.RegisterPowerHardware(data[0], int.Parse(data[1]), int.Parse(data[2]));
                    break;

                case "RegisterHeavyHardware":
                    this.systemManager.RegisterHeavyHardware(data[0], int.Parse(data[1]), int.Parse(data[2]));
                    break;

                case "RegisterExpressSoftware":
                    this.systemManager.RegisterExpressSoftware(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]));
                    break;

                case "RegisterLightSoftware":
                    this.systemManager.RegisterLightSoftware(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]));
                    break;

                case "ReleaseSoftwareComponent":
                    this.systemManager.ReleaseSoftwareComponent(data[0], data[1]);
                    break;

                case "Analyze":
                    this.writer.WriteLine(this.systemManager.Analyze());
                    break;

                case "Dump":
                    var hardware = this.systemManager.RemoveHardware(data[0]);
                    if (hardware != null)
                    {
                        this.dumpManager.Dump(data[0], hardware);
                    }
                    break;

                case "Restore":
                    var hardware1 = this.dumpManager.Restore(data[0]);
                    if (hardware1 != null)
                    {
                        this.systemManager.AddHardware(data[0], hardware1);
                    }
                    break;

                case "Destroy":
                    this.dumpManager.Destroy(data[0]);
                    break;

                case "DumpAnalyze":
                    this.writer.WriteLine(this.dumpManager.DumpAnalyze());
                    break;

                case "System Split":
                    this.writer.WriteLine(this.systemManager.SystemSplit());
                    this.isSystemSplit = true;
                    break;
            }
        }
    }
}