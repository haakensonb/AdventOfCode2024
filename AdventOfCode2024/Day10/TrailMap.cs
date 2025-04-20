using AdventOfCode2024.Common.Point;

namespace AdventOfCode2024.Day10;

public record TrailMap
{
    private List<List<int>> _map;

    public TrailMap(string input)
    {
        _map = LoadMap(input);
    }

    private List<List<int>> LoadMap(string input)
    {
        var map = new List<List<int>>();
        var lines = input.Split("\n");
        foreach (var line in lines)
        {
            var newLine = new List<int>();
            foreach (var c in line)
            {
                if (!c.Equals('.'))
                {
                    newLine.Add(int.Parse(c.ToString()));
                }
                else
                {
                    newLine.Add(-1);
                }
            }

            map.Add(newLine);
        }

        return map;
    }

    private bool IsWithin(Point p)
    {
        var xMax = _map.Count - 1;
        var yMax = _map[0].Count - 1;
        return (p.X >= 0 && p.X <= xMax && p.Y >= 0 && p.Y <= yMax);
    }

    private bool IsValidPoint(Point p)
    {
        if (IsWithin(p))
        {
            var val = _map[p.X][p.Y];
            return val >= 0;
        }

        return false;
    }

    private List<Point> GetValidNeighbors(Point p)
    {
        var neighbors = new List<Point>();
        var left = new Point(p.X, p.Y - 1);
        if (IsValidPoint(left))
            neighbors.Add(left);
        var right = new Point(p.X, p.Y + 1);
        if (IsValidPoint(right))
            neighbors.Add(right);
        var up = new Point(p.X - 1, p.Y);
        if (IsValidPoint(up))
            neighbors.Add(up);
        var down = new Point(p.X + 1, p.Y);
        if (IsValidPoint(down))
            neighbors.Add(down);
        return neighbors;
    }

    private List<Point> GetTrailheads()
    {
        var trailheads = new List<Point>();
        for (var i = 0; i < _map.Count; i++)
        {
            for (var j = 0; j < _map[i].Count; j++)
            {
                var val = _map[i][j];
                if (val == 0)
                {
                    trailheads.Add(new Point(i, j));
                }
            }
        }

        return trailheads;
    }

    private int GetTrailheadScore(Point p)
    {
        var score = 0;
        var visited = new HashSet<Point>();

        void Traversal(Node node)
        {
            var currVal = _map[node.Point.X][node.Point.Y];

            // If it's not the starting case and currVal isn't an increase of prevVal, then it's an invalid path.
            if (node.Previous != null)
            {
                var prevVal = _map[node.Previous.Point.X][node.Previous.Point.Y];
                if (currVal != prevVal + 1)
                {
                    return;
                }
            }

            visited.Add(node.Point);

            if (currVal == 9)
            {
                score += 1;
                return;
            }

            var neighbors = GetValidNeighbors(node.Point);
            foreach (var neighbor in neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    Traversal(new Node(node, neighbor));
                }
            }
        }

        Traversal(new Node(null, p));

        return score;
    }

    private int GetTrailheadRating(Point p)
    {
        var visited = new HashSet<Node>();
        var rating = new HashSet<Node>();

        void Traversal(Node node)
        {
            var currVal = _map[node.Point.X][node.Point.Y];

            if (currVal == 9)
            {
                rating.Add(node);
            }

            visited.Add(node);

            var neighbors = GetValidNeighbors(node.Point);
            foreach (var neighbor in neighbors)
            {
                var neighborNode = new Node(node, neighbor);
                var nextVal = _map[neighborNode.Point.X][neighborNode.Point.Y];
                if (nextVal == currVal + 1)
                {
                    if (!visited.Contains(neighborNode))
                    {
                        Traversal(neighborNode);
                    }
                }
            }
        }

        Traversal(new Node(null, p));

        return rating.Count;
    }

    public int ScoreSum()
    {
        var trailheads = GetTrailheads();
        return trailheads.Select(GetTrailheadScore).Sum();
    }

    public int RatingSum()
    {
        var trailheads = GetTrailheads();
        return trailheads.Select(GetTrailheadRating).Sum();
    }
}

