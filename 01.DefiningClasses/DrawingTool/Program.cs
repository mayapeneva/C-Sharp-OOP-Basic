using System;

namespace DrawingTool
{
    public class Program
    {
        public static void Main()
        {
            Shape shape;
            var input = Console.ReadLine();
            if (input == "Square")
            {
                shape = new Square(int.Parse(Console.ReadLine()));
            }
            else
            {
                shape = new Rectangle(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            }

            var corDraw = new CorDraw(shape);
            corDraw.Draw();
        }
    }
}