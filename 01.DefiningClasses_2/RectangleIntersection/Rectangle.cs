public class Rectangle
{
    public Rectangle(string id, double width, double height, double leftX, double topY)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.LeftX = leftX;
        this.DownY = topY;
    }

    public string Id { get; }
    public double Width { get; }
    public double Height { get; }
    public double LeftX { get; }
    public double DownY { get; }

    public bool IntersectWith(Rectangle other)
    {
        var thisRightX = this.LeftX + this.Width;
        var thisTopY = this.DownY + this.Height;

        var otherRightX = other.LeftX + other.Width;
        var otherTopY = other.DownY + other.Height;

        return this.LeftX <= otherRightX
            && thisRightX >= other.LeftX
            && this.DownY <= otherTopY && thisTopY >= other.DownY;
    }
}