using System;

namespace DrawingTool
{
    public class Rectangle : Shape
    {
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; }

        public int Height { get; }

        public override void Draw()
        {
            var firstLine = '|' + new string('-', this.Width) + '|';
            var midLine = '|' + new string(' ', this.Width) + '|';

            Console.WriteLine(firstLine);
            for (int i = 0; i < this.Height - 2; i++)
            {
                Console.WriteLine(midLine);
            }
            Console.WriteLine(firstLine);
        }
    }
}