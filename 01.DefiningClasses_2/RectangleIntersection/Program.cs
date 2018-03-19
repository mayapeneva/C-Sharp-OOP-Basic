using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var rectangles = new List<Rectangle>();

        var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var numberOfRectangles = int.Parse(input[0]);
        var intersectionChecks = int.Parse(input[1]);

        GatherRectanglesInfo(rectangles, numberOfRectangles);

        CheckForIntersectionAndPrintresult(rectangles, intersectionChecks);
    }

    private static void CheckForIntersectionAndPrintresult(List<Rectangle> rectangles, int intersectionChecks)
    {
        for (int j = 0; j < intersectionChecks; j++)
        {
            var pairs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var firstRectangle = rectangles.First(r => r.Id.Equals(pairs[0]));
            var secondRectangle = rectangles.First(r => r.Id.Equals(pairs[1]));

            if (firstRectangle.Equals(null) || secondRectangle.Equals(null))
            {
                Console.WriteLine("false");
            }

            Console.WriteLine(firstRectangle.IntersectWith(secondRectangle) ? "true" : "false");
        }
    }

    private static void GatherRectanglesInfo(List<Rectangle> rectangles, int numberOfRectangles)
    {
        for (int i = 0; i < numberOfRectangles; i++)
        {
            var rectangleInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var id = rectangleInput[0];
            var width = double.Parse(rectangleInput[1]);
            var height = double.Parse(rectangleInput[2]);
            var leftX = double.Parse(rectangleInput[3]);
            var topY = double.Parse(rectangleInput[4]);

            rectangles.Add(new Rectangle(id, width, height, leftX, topY));
        }
    }
}