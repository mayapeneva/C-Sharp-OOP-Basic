namespace DrawingTool
{
    public class CorDraw
    {
        public CorDraw(Shape shape)
        {
            this.Shape = shape;
        }

        public Shape Shape { get; }

        public void Draw()
        {
            this.Shape.Draw();
        }
    }
}