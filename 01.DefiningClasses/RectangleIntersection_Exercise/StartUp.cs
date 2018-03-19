using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rectangles = new Dictionary<string, Rectangle>();
            for (int i = 0; i < numbers[0]; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                rectangles[input[0]] = new Rectangle(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]), double.Parse(input[4]));
            }

            var ifIntersect = false;
            for (int j = 0; j < numbers[1]; j++)
            {
                var idPairs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var firstRect = rectangles[idPairs[0]];
                var secondRect = rectangles[idPairs[1]];

                if ((firstRect.TopLeftCornerX >= secondRect.TopLeftCornerX && firstRect.TopLeftCornerX <= secondRect.topRightCornerX
                    && firstRect.TopLeftCornerY >= secondRect.bottomLeftCornerY && firstRect.TopLeftCornerY <= secondRect.TopLeftCornerY)
                    || (firstRect.topRightCornerX >= secondRect.TopLeftCornerX && firstRect.topRightCornerX <= secondRect.topRightCornerX
                    && firstRect.topRightCornerY >= secondRect.bottomRightCornerY && firstRect.topRightCornerY <= secondRect.topRightCornerY)
                    || (firstRect.bottomRightCornerX >= secondRect.bottomLeftCornerX && firstRect.bottomRightCornerX <= secondRect.bottomRightCornerX
                    && firstRect.bottomRightCornerY >= secondRect.bottomLeftCornerY && firstRect.bottomRightCornerY <= secondRect.TopLeftCornerY)
                    || (firstRect.bottomLeftCornerX >= secondRect.bottomLeftCornerX && firstRect.bottomLeftCornerX <= secondRect.bottomRightCornerX
                    && firstRect.bottomLeftCornerY >= secondRect.bottomLeftCornerY && firstRect.bottomLeftCornerY <= secondRect.TopLeftCornerY))
                {
                    ifIntersect = true;
                }

                Console.WriteLine(ifIntersect.ToString().ToLower());
            }
        }
    }
}