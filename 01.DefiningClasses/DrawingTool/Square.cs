using System;

namespace DrawingTool
{
    public class Square : Shape
    {
        public Square(int side)
        {
            this.Side = side;
        }

        public int Side { get; }

        public override void Draw()
        {
            var firstLine = '|' + new string('-', this.Side) + '|';
            var midLine = '|' + new string(' ', this.Side) + '|';

            Console.WriteLine(firstLine);
            for (int i = 0; i < this.Side - 2; i++)
            {
                Console.WriteLine(midLine);
            }
            Console.WriteLine(firstLine);
        }
    }
}