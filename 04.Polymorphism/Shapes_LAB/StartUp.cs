using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var rectangleInfo = Console.ReadLine().Split().Select(double.Parse).ToArray();
        Shape rectangle = new Rectangle(rectangleInfo[0], rectangleInfo[1]);
        Shape circle = new Circle(double.Parse(Console.ReadLine()));

        Console.WriteLine($"Rectangle area: {rectangle.CalculateArea()}");
        Console.WriteLine($"Rectangle perimeter: {rectangle.CalculatePerimeter()}");
        Console.WriteLine(rectangle.Draw());

        Console.WriteLine($"Circle area: {circle.CalculateArea()}");
        Console.WriteLine($"Circle perimeter: {circle.CalculatePerimeter()}");
        Console.WriteLine(circle.Draw());
    }
}