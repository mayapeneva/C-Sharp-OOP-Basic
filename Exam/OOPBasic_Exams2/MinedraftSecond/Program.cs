public class Program
{
    public static void Main()
    {
        var harvesterFactory = new HarvesterFactory();
        var providerFactory = new ProviderFactory();
        var draftManager = new DraftManager(harvesterFactory, providerFactory);
        var engine = new Engine(draftManager);
        engine.Run();
    }
}