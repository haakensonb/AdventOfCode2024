// TODO: fix namespace

namespace AdventOfCode2024;

public record PointDay10(int X, int Y);

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

    private bool IsWithin(PointDay10 p)
    {
        var xMax = _map.Count - 1;
        var yMax = _map[0].Count - 1;
        return (p.X >= 0 && p.X <= xMax && p.Y >= 0 && p.Y <= yMax);
    }

    private bool IsValidPointDay10(PointDay10 p)
    {
        if (IsWithin(p))
        {
            var val = _map[p.X][p.Y];
            return val >= 0;
        }

        return false;
    }

    private List<PointDay10> GetValidNeighbors(PointDay10 p)
    {
        var neighbors = new List<PointDay10>();
        var left = new PointDay10(p.X, p.Y - 1);
        if (IsValidPointDay10(left))
            neighbors.Add(left);
        var right = new PointDay10(p.X, p.Y + 1);
        if (IsValidPointDay10(right))
            neighbors.Add(right);
        var up = new PointDay10(p.X - 1, p.Y);
        if (IsValidPointDay10(up))
            neighbors.Add(up);
        var down = new PointDay10(p.X + 1, p.Y);
        if (IsValidPointDay10(down))
            neighbors.Add(down);
        return neighbors;
    }

    private List<PointDay10> GetTrailheads()
    {
        var trailheads = new List<PointDay10>();
        for (var i = 0; i < _map.Count; i++)
        {
            for (var j = 0; j < _map[i].Count; j++)
            {
                var val = _map[i][j];
                if (val == 0)
                {
                    trailheads.Add(new PointDay10(i, j));
                }
            }
        }

        return trailheads;
    }

    private int GetTrailheadScore(PointDay10 p)
    {
        var score = 0;
        var visited = new HashSet<PointDay10>();

        void Traversal(PointDay10 prev, PointDay10 curr)
        {
            var prevVal = _map[prev.X][prev.Y];
            var currVal = _map[curr.X][curr.Y];

            // If it's not the starting case and currVal isn't an increase of prevVal, then it's an invalid path.
            if ((prev != curr) && (currVal != prevVal + 1))
            {
                return;
            }

            // Only mark valid paths as visited
            visited.Add(curr);

            if (currVal == 9)
            {
                score += 1;
                return;
            }

            var neighbors = GetValidNeighbors(curr);
            foreach (var neighbor in neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    Traversal(curr, neighbor);
                }
            }
        }

        Traversal(p, p);

        return score;
    }

    public int ScoreSum()
    {
        var trailheads = GetTrailheads();
        return trailheads.Select(GetTrailheadScore).Sum();
    }
}

public class Day10 : IDay
{
    public string SolvePart1(string input)
    {
        var trailMap = new TrailMap(input);
        return trailMap.ScoreSum().ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}