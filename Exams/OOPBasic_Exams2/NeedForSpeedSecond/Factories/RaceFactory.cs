public class RaceFactory
{
    public Race CreateRace(string type, int length, string route, int prizePool)
    {
        if (type.Equals("Casual"))
        {
            return new CasualRace(length, route, prizePool);
        }

        if (type.Equals("Drag"))
        {
            return new DragRace(length, route, prizePool);
        }

        return new DriftRace(length, route, prizePool);
    }
}