using System;
using System.Text;

public class DrawingTool
{
    public DrawingTool(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Width { get; }
    public int Height { get; }

    public override string ToString()
    {
        var result = new StringBuilder();
        var startRow = new StringBuilder();
        startRow.Append('|');
        startRow.Append(new string('-', this.Width));
        startRow.Append('|');
        result.Append(Environment.NewLine);

        result.AppendLine(startRow.ToString());
        for (int i = 1; i < this.Height - 1; i++)
        {
            result.Append('|');
            result.Append(new string(' ', this.Width));
            result.Append('|');
            result.Append(Environment.NewLine);
        }
        result.AppendLine(startRow.ToString());

        return result.ToString();
    }
}