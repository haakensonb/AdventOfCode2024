namespace AdventOfCode2024.Day12;

public record Region
{
    public HashSet<Point> points;
    public int perimeter;

    public Region()
    {
        points = new HashSet<Point>();
        perimeter = 0;
    }

    public int GetPrice()
    {
        return points.Count * perimeter;
    }
}