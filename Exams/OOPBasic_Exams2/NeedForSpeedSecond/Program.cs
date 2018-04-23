public class Program
{
    public static void Main()
    {
        var carManager = new CarManager();
        var engine = new Engine(carManager);
        engine.Run();
    }
}