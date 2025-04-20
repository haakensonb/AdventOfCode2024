namespace AdventOfCode2024.Common.Point;

public record Point(int X, int Y)
{
    public Point Add(Point newPoint)
    {
        return new Point(X + newPoint.X, Y + newPoint.Y);
    }

    public Point Distance(Point newPoint)
    {
        var xDiff = newPoint.X - X;
        var yDiff = newPoint.Y - Y;
        return new Point(xDiff, yDiff);
    }

    public Point Negate()
    {
        return new Point(-X, -Y);
    }
}
