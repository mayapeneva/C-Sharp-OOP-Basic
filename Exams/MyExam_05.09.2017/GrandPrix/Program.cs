public class Program
{
    public static void Main()
    {
        var raceTower = new RaceTower();
        var engine = new Engine(raceTower);
        engine.Run();
    }
}