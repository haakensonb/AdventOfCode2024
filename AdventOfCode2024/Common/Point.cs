namespace AdventOfCode2024.Common;

public record Point(int X, int Y)
{
    public Point Add(Point newPoint)
    {
        return new Point(X + newPoint.X, Y + newPoint.Y);
    }
}
