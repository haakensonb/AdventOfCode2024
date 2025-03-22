namespace AdventOfCode2024.Day8;

public record Point(int x, int y)
{
    public int x = x;
    public int y = y;

    public Point Distance(Point newPoint)
    {
        var xDiff = newPoint.x - x;
        var yDiff = newPoint.y - y;
        return new Point(xDiff, yDiff);
    }

    public Point Add(Point newPoint)
    {
        return new Point(x + newPoint.x, y + newPoint.y);
    }

    public Point Negate()
    {
        return new Point(-x, -y);
    }
}