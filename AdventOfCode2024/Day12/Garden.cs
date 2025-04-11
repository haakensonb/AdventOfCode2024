using System.Runtime.InteropServices;

namespace AdventOfCode2024.Day12;

public class Garden
{
    private List<List<char>> _garden;

    private List<Region> _regions;

    public Garden(string input)
    {
        _garden = new List<List<char>>();
        _regions = new List<Region>();

        var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in lines)
        {
            var formattedLine = line.ToCharArray().ToList();
            _garden.Add(formattedLine);
        }
    }

    private bool IsInGarden(Point p)
    {
        return (p.X >= 0 && p.X < _garden.Count) && (p.Y >= 0 && p.Y < _garden[0].Count);
    }

    private List<Point> GetNeighbors(Point p)
    {
        var neighbors = new List<Point>();

        var directionModifiers = new List<Point>{
            new(-1, 0), // up
            new(1, 0), // down
            new(0, -1), // left
            new(0, 1) // right
        };

        foreach (var direction in directionModifiers)
        {
            var newPoint = p.Add(direction);
            if (IsInGarden(newPoint))
                neighbors.Add(newPoint);
        }

        return neighbors;
    }

    private int GetPerimeter(char pointVal, List<Point> neighbors)
    {
        var neighborVals = neighbors.Select(n => _garden[n.X][n.Y]);
        var numMatchingNeighbors = neighborVals.Where(nv => nv == pointVal).Count();
        // Perimeter for single point has 4 max sides minus matching neighbors where fence isn't needed
        return 4 - numMatchingNeighbors;
    }

    private Region BFSExpandRegion(Point startingPoint)
    {
        var region = new Region();

        var queue = new Queue<Point>();
        var visited = new HashSet<Point>
        {
            startingPoint
        };
        queue.Enqueue(startingPoint);

        while (queue.Count > 0)
        {
            var point = queue.Dequeue();
            var pointVal = _garden[point.X][point.Y];
            var neighbors = GetNeighbors(point);
            var perimeter = GetPerimeter(pointVal, neighbors);
            region.perimeter += perimeter;
            foreach (var neighbor in neighbors)
            {
                var neighborVal = _garden[neighbor.X][neighbor.Y];
                if (!visited.Contains(neighbor) && (pointVal == neighborVal))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        region.points.UnionWith(visited);

        return region;
    }

    private bool IsPointInExistingRegion(Point point)
    {
        foreach (var region in _regions)
        {
            if (region.points.Contains(point))
                return true;
        }
        return false;
    }

    public List<Region> GetRegions()
    {
        for (var i = 0; i < _garden.Count; i++)
        {
            for (var j = 0; j < _garden[i].Count; j++)
            {
                var point = new Point(i, j);

                if (!IsPointInExistingRegion(point))
                {
                    var newRegion = BFSExpandRegion(point);
                    _regions.Add(newRegion);
                }
            }
        }
        return _regions;
    }
}