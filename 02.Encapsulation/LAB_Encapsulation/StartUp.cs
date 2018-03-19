using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var people = new List<Person>();
        for (int i = 0; i < n; i++)
        {
            var command = Console.ReadLine().Split();
            people.Add(new Person(command[0], command[1], int.Parse(command[2]), double.Parse(command[3])));
        }

        var team = new Team("Varna");
        people.ForEach(p => team.AddPlayer(p));
        Console.WriteLine($"First team have {team.FirstTeam.Count} players");
        Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players");
    }
}
