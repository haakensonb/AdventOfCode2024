namespace AdventOfCode2024.Day12;

public record Point(int X, int Y)
{
    public Point Add(Point newPoint)
    {
        return new Point(X + newPoint.X, Y + newPoint.Y);
    }
}