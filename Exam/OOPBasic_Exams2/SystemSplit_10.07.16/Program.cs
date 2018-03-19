public class Program
{
    public static void Main()
    {
        var systemManager = new SystemManager();
        var dumpManager = new DumpManager();
        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();
        var engine = new Engine(systemManager, dumpManager, reader, writer);
        engine.Run();
    }
}