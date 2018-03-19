using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get => this.length;
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine("Length cannot be zero or negative.");
                Environment.Exit(0);
            }

            this.length = value;
        }
    }

    public double Width
    {
        get => this.width;
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine("Width cannot be zero or negative.");
                Environment.Exit(0);
            }

            this.width = value;
        }
    }

    public double Height
    {
        get => this.height;
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine("Height cannot be zero or negative.");
                Environment.Exit(0);
            }

            this.height = value;
        }
    }

    public double CalculateSurfaceArea()
    {
        return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
    }

    public double CalculateLateralSurface()
    {
        return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
    }

    public double CalculateVolume()
    {
        return this.Length * this.Width * this.Height;
    }
}