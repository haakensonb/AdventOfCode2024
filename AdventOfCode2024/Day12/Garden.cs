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

    private Dictionary<string, Point> GetNeighbors(Point p)
    {
        var neighbors = new Dictionary<string, Point>();

        List<string> directions = ["up", "down", "left", "right"];

        var directionModifiers = new List<Point>{
            new(-1, 0), // up
            new(1, 0), // down
            new(0, -1), // left
            new(0, 1) // right
        };

        for (var i = 0; i < directions.Count; i++)
        {
            var newPoint = p.Add(directionModifiers[i]);
            if (IsInGarden(newPoint))
                neighbors.Add(directions[i], newPoint);
        }

        return neighbors;
    }

    private int GetCorners(Point p, Dictionary<string, Point> neighbors)
    {
        int corners = 0;
        var val = _garden[p.X][p.Y];

        neighbors.TryGetValue("up", out Point? upP);
        var up = upP != null ? _garden[upP.X][upP.Y] : '0';
        neighbors.TryGetValue("down", out Point? downP);
        var down = downP != null ? _garden[downP.X][downP.Y] : '0';
        neighbors.TryGetValue("left", out Point? leftP);
        var left = leftP != null ? _garden[leftP.X][leftP.Y] : '0';
        neighbors.TryGetValue("right", out Point? rightP);
        var right = rightP != null ? _garden[rightP.X][rightP.Y] : '0';

        // Outer corners
        if (up != val && left != val)
            corners += 1;
        if (up != val && right != val)
            corners += 1;
        if (down != val && left != val)
            corners += 1;
        if (down != val && right != val)
            corners += 1;

        Point upLeftDiagP = p.Add(new Point(-1, -1));
        Point upRightDiagP = p.Add(new Point(-1, 1));
        Point downLeftDiagP = p.Add(new Point(1, -1));
        Point downRightDiagP = p.Add(new Point(1, 1));
        var upLeftDiag = IsInGarden(upLeftDiagP) ? _garden[upLeftDiagP.X][upLeftDiagP.Y] : '0';
        var upRightDiag = IsInGarden(upRightDiagP) ? _garden[upRightDiagP.X][upRightDiagP.Y] : '0';
        var downLeftDiag = IsInGarden(downLeftDiagP) ? _garden[downLeftDiagP.X][downLeftDiagP.Y] : '0';
        var downRightDiag = IsInGarden(downRightDiagP) ? _garden[downRightDiagP.X][downRightDiagP.Y] : '0';

        // Inner corners
        if (up == val && left == val && upLeftDiag != val)
            corners += 1;
        if (up == val && right == val && upRightDiag != val)
            corners += 1;
        if (down == val && left == val && downLeftDiag != val)
            corners += 1;
        if (down == val && right == val && downRightDiag != val)
            corners += 1;

        return corners;
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
            var neighborsList = neighbors.Values.ToList();

            var perimeter = GetPerimeter(pointVal, neighborsList);
            var corners = GetCorners(point, neighbors);

            region.perimeter += perimeter;
            // Number of corners is equal to the number of sides
            region.sides += corners;

            foreach (var neighbor in neighborsList)
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