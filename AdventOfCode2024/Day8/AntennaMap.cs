namespace AdventOfCode2024.Day8;

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