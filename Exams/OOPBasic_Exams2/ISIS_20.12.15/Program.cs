public class Program
{
    public static void Main()
    {
        var hackersManager = new HackersManager();
        var engine = new Engine(hackersManager);
        engine.Run();
    }
}