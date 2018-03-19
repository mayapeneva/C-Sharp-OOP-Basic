public class Miner : IMiner
{
    private readonly string id;

    public Miner(string id)
    {
        this.id = id;
    }

    public string Id => this.id;
}