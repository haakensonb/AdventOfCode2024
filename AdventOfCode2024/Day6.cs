namespace AdventOfCode2024;

public enum Direction
{
    North = '^',
    South = 'v',
    East = '>',
    West = '<'
}

public class Guard(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public Direction CurrentDirection { get; set; } = Direction.North;

    public void Rotate()
    {
        CurrentDirection = CurrentDirection switch
        {
            Direction.North => Direction.East,
            Direction.South => Direction.West,
            Direction.East => Direction.South,
            Direction.West => Direction.North,
            _ => CurrentDirection
        };
    }
}

public class PuzzleMap
{
    private List<char[]> _map;
    private Guard _guard;

    private (int x, int y) FindGuardLocation()
    {
        for (int i = 0; i < _map.Count; i++)
        {
            var line = _map[i];
            var index = Array.IndexOf(line, '^');
            if (index > -1)
            {
                return (i, index);
            }
        }

        // This shouldn't ever happen. Ideally raise an error here.
        return (0, 0);
    }

    private bool IsOnMap(int x, int y)
    {
        return (x >= 0 && x < _map.Count) && (y >= 0 && y < _map[0].Length);
    }

    private (int x, int y) LocationModifier()
    {
        var locationModifier = _guard.CurrentDirection switch
        {
            Direction.North => (x: -1, y: 0),
            Direction.South => (x: 1, y: 0),
            Direction.East => (x: 0, y: 1),
            Direction.West => (x: 0, y: -1),
            _ => (x: 0, y: 0)
        };
        return locationModifier;
    }

    private bool IsGuardBlocked()
    {
        var locationModifier = LocationModifier();
        var combinedX = _guard.X + locationModifier.x;
        var combinedY = _guard.Y + locationModifier.y;
        // Guard is about to leave the map
        if (!IsOnMap(combinedX, combinedY))
        {
            return false;
        }

        var objectInFront = _map[combinedX][combinedY];
        // Blocked
        return objectInFront == '#';
    }

    private void MoveGuard()
    {
        // If there is something directly in front of you, turn right 90 degrees.
        if (IsGuardBlocked())
        {
            _guard.Rotate();
        }

        // Otherwise, take a step forward.
        var locationModifier = LocationModifier();
        var combinedX = _guard.X + locationModifier.x;
        var combinedY = _guard.Y + locationModifier.y;

        _map[_guard.X][_guard.Y] = 'X';
        _guard.X = combinedX;
        _guard.Y = combinedY;
        var charVal = _guard.CurrentDirection switch
        {
            Direction.North => (char)Direction.North,
            Direction.South => (char)Direction.South,
            Direction.East => (char)Direction.East,
            Direction.West => (char)Direction.West,
            _ => _map[combinedX][combinedY]
        };
        if (IsOnMap(combinedX, combinedY))
        {
            _map[combinedX][combinedY] = charVal;
        }
    }

    public void PatrolSimulation()
    {
        var keepGoing = true;
        while (keepGoing)
        {
            if (!IsOnMap(_guard.X, _guard.Y))
            {
                keepGoing = false;
            }
            else
            {
                MoveGuard();
            }
        }
    }

    public int CountXs()
    {
        return _map.Sum(line => line.Count(c => c == 'X'));
    }

    public PuzzleMap(string input)
    {
        var lines = input.Split('\n');
        _map = lines.Select(line => line.ToCharArray()).ToList();

        var guardStart = FindGuardLocation();
        _guard = new Guard(guardStart.x, guardStart.y);
    }
}

public class Day6 : IDay
{
    public string SolvePart1(string input)
    {
        var puzzleMap = new PuzzleMap(input);
        puzzleMap.PatrolSimulation();
        return puzzleMap.CountXs().ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}