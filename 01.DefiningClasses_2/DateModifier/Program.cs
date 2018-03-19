using System;

public class Program
{
    public static void Main()
    {
        var dateModifier = new DateModifier();
        Console.WriteLine(dateModifier.CalculateDifference(Console.ReadLine(), Console.ReadLine()));
    }
}