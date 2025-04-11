namespace AdventOfCode2024.Day12;

public record Region
{
    public HashSet<Point> points;
    public int perimeter;
    public int sides;

    public Region()
    {
        points = new HashSet<Point>();
        perimeter = 0;
        sides = 0;
    }

    public int GetPrice()
    {
        return points.Count * perimeter;
    }

    public int GetBulkPrice()
    {
        return points.Count * sides;
    }
}