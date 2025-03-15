namespace AdventOfCode2024;

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
};

public record AntennaMap
{
    private readonly List<List<char>> _map;

    public AntennaMap(string input)
    {
        _map = new List<List<char>>();
        foreach (var line in input.Split("\n"))
        {
            var charList = line.ToCharArray();
            _map.Add(charList.ToList());
        }
    }

    public bool IsWithin(Point p)
    {
        var xMax = _map.Count - 1;
        var yMax = _map[0].Count - 1;
        return (p.x >= 0 && p.x <= xMax && p.y >= 0 && p.y <= yMax);
    }

    public Dictionary<char, List<Point>> GetFrequencyPoints()
    {
        var frequencyPoints = new Dictionary<char, List<Point>>();
        for (var i = 0; i < _map.Count; i++)
        {
            for (var j = 0; j < _map[i].Count; j++)
            {
                var currentChar = _map[i][j];
                if (currentChar != '.')
                {
                    var currentPoint = new Point(i, j);
                    if (frequencyPoints.ContainsKey(currentChar))
                    {
                        frequencyPoints[currentChar].Add(currentPoint);
                    }
                    else
                    {
                        frequencyPoints.Add(currentChar, new List<Point> { currentPoint });
                    }    
                }
            }
        }
        return frequencyPoints;
    }
}

public class Day8 : IDay
{
    public string SolvePart1(string input)
    {
        var antennaMap = new AntennaMap(input);
        var frequencyPoints = antennaMap.GetFrequencyPoints();
        var uniqueAntinodePoints = new HashSet<Point>();
        foreach (var frequency in frequencyPoints)
        {
            var points = frequency.Value;
            foreach (var point1 in points)
            {
                foreach (var point2 in points)
                {
                    if (!point1.Equals(point2))
                    {
                        var dist = point1.Distance(point2);
                        var antinode1 = point1.Add(dist.Negate());
                        var antinode2 = point2.Add(dist);
                        if (antennaMap.IsWithin(antinode1))
                        {
                            uniqueAntinodePoints.Add(antinode1);
                        }

                        if (antennaMap.IsWithin(antinode2))
                        {
                            uniqueAntinodePoints.Add(antinode2);
                        }
                    }
                }
            }
        }
        return uniqueAntinodePoints.Count.ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}