using System;

public class Program
{
    public static void Main()
    {
        var figureType = Console.ReadLine();
        if (figureType.Equals("Square"))
        {
            var side = int.Parse(Console.ReadLine());
            Console.WriteLine(new DrawingTool(side, side));
        }
        else
        {
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            Console.WriteLine(new DrawingTool(width, height));
        }
    }
}