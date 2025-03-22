// TODO: fix namespace

namespace AdventOfCode2024;

public record PointDay10(int X, int Y)
{
    public override string ToString() => $"({X}, {Y})";
}

public record Node(Node? Previous, PointDay10 Point, string Path);

public record Node2(Node2? Previous, PointDay10 Point);

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

        // Depth first search
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

    private int GetTrailheadRating(PointDay10 p)
    {
        // var rating = 0;
        var visited = new HashSet<Node2>();
        var rating = new HashSet<Node2>();

        // Depth first search
        void Traversal(Node2 node)
        {
            var currVal = _map[node.Point.X][node.Point.Y];


            if (currVal == 9)
            {
                // rating += 1;
                rating.Add(node);
            }

            // Only mark valid paths as visited
            visited.Add(node);
            var neighbors = GetValidNeighbors(node.Point);
            foreach (var neighbor in neighbors)
            {
                var neighborNode = new Node2(node, neighbor);
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

        Traversal(new Node2(null, p));

        // return rating;
        return rating.Count;
    }

    // private string GetNodePath(Node node)
    // {
    //     if (node.Previous == null)
    //         return "";
    //     var path = new List<PointDay10>();
    //     var currentNode = node;
    //     while (currentNode != null)
    //     {
    //         path.Add(currentNode.Val);
    //         currentNode = currentNode.Previous;
    //     }
    //
    //     return string.Join(",", path.Select(p => p.ToString()));
    // }

    // private int GetTrailheadRating(PointDay10 p)
    // {
    //     // Breadth first search
    //     var uniquePaths = new HashSet<string>();
    //     var visited = new HashSet<Node>();
    //     var queue = new Queue<Node>();
    //     var firstNode = new Node(null, p, "");
    //     visited.Add(firstNode);
    //     queue.Enqueue(firstNode);
    //     while (queue.Count > 0)
    //     {
    //         var node = queue.Dequeue();
    //         // Check if valid
    //         var currentVal = _map[node.Point.X][node.Point.Y];
    //         int previousVal = 0;
    //         if (node.Previous != null)
    //         {
    //             previousVal = _map[node.Previous.Point.X][node.Previous.Point.Y];
    //         }
    //
    //         if (currentVal == 9)
    //         {
    //             uniquePaths.Add(node.Path);
    //         }
    //         else if (node.Previous == null || currentVal == previousVal + 1)
    //         {
    //             var neighbors = GetValidNeighbors(node.Point);
    //             foreach (var neighbor in neighbors)
    //             {
    //                 // if (!visited.Contains(node))
    //                 // {
    //                 //     // var neighborNode = new Node(null, neighbor, node.Path + neighbor.ToString());
    //                 //     // visited.Add(neighborNode);
    //                 //     var newNode = new Node(node, neighbor, node.Path + node.Point.ToString());
    //                 //     visited.Add(newNode);
    //                 //     queue.Enqueue(newNode);
    //                 // }
    //                 var newNode = new Node(node, neighbor, node.Path + node.Point.ToString());
    //                 queue.Enqueue(newNode);
    //             }
    //         }
    //     }
    //
    //     return uniquePaths.Count;
    // }

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

public class Day10 : IDay
{
    public string SolvePart1(string input)
    {
        var trailMap = new TrailMap(input);
        return trailMap.ScoreSum().ToString();
    }

    public string SolvePart2(string input)
    {
        var trailMap = new TrailMap(input);
        return trailMap.RatingSum().ToString();
    }
}