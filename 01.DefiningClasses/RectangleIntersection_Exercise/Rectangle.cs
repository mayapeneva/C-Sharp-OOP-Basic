namespace RectangleIntersection_Exercise
{
    public class Rectangle
    {
        private double width;
        private double height;
        private double topLeftCornerX;
        private double topLeftCornerY;

        public Rectangle(double width, double height, double topleftCornerX, double topleftCornerY)
        {
            this.width = width;
            this.height = height;
            this.topLeftCornerX = topleftCornerX;
            this.topLeftCornerY = topleftCornerY;
        }

        public double Width => this.width;
        public double Height => this.height;

        public double TopLeftCornerX => this.topLeftCornerX;
        public double TopLeftCornerY => this.topLeftCornerY;

        public double topRightCornerX => topLeftCornerX + width;
        public double topRightCornerY => topLeftCornerY;

        public double bottomLeftCornerX => topLeftCornerX;
        public double bottomLeftCornerY => topLeftCornerY - height;

        public double bottomRightCornerX => topRightCornerX;
        public double bottomRightCornerY => bottomLeftCornerY;
    }
}