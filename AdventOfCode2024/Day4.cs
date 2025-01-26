namespace AdventOfCode2024;

public record Coord
{
    public int X { get; set; }
    public int Y { get; set; }

    public Coord(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Puzzle
{
    private List<List<string>> _puzzle;

    public Puzzle(string input)
    {
        _puzzle = new List<List<string>>();
        var lines = input.Split("\n").ToList();
        foreach (var line in lines)
        {
            var splitLine = line.Select(c => c.ToString()).ToList();
            _puzzle.Add(splitLine);
        }
    }

    private bool IsInBounds(int i, int j)
    {
        return ((i >= 0 && j >= 0) && (i < _puzzle.Count && j < _puzzle[i].Count));
    }

    private List<List<Coord>> GetAdjacentCoordGroups(int x, int y, int totalDistance)
    {
        var coords = new List<List<Coord>>();
        var up = new List<Coord>();
        var down = new List<Coord>();
        var left = new List<Coord>();
        var right = new List<Coord>();
        var diagUpRight = new List<Coord>();
        var diagDownRight = new List<Coord>();
        var diagUpLeft = new List<Coord>();
        var diagDownLeft = new List<Coord>();
        for (int i = 0; i < totalDistance; i++)
        {
            // Up
            if (IsInBounds(x - i, y))
                up.Add(new Coord(x - i, y));
            // Down
            if (IsInBounds(x + i, y))
                down.Add(new Coord(x + i, y));
            // Left
            if (IsInBounds(x, y - i))
                left.Add(new Coord(x, y - i));
            // Right
            if (IsInBounds(x, y + i))
                right.Add(new Coord(x, y + i));
            // Diagonal Up Right
            if (IsInBounds(x - i, y + i))
                diagUpRight.Add(new Coord(x - i, y + i));
            // Diagonal Down Right
            if (IsInBounds(x + i, y + i))
                diagDownRight.Add(new Coord(x + i, y + i));
            // Diagonal Up Left
            if (IsInBounds(x - i, y - i))
                diagUpLeft.Add(new Coord(x - i, y - i));
            // Diagonal Down Left
            if (IsInBounds(x + i, y - i))
                diagDownLeft.Add(new Coord(x + i, y - i));
        }

        coords.Add(up);
        coords.Add(down);
        coords.Add(left);
        coords.Add(right);
        coords.Add(diagUpRight);
        coords.Add(diagDownRight);
        coords.Add(diagUpLeft);
        coords.Add(diagDownLeft);

        return coords;
    }

    private List<List<Coord>> GetXCoordGroups(int x, int y)
    {
        var coords = new List<List<Coord>>();
        var group = new List<Coord>();
        group.Add(new Coord(x, y));
        // Diagonal Up Right
        if (IsInBounds(x - 1, y + 1))
            group.Add(new Coord(x - 1, y + 1));
        // Diagonal Down Right
        if (IsInBounds(x + 1, y + 1))
            group.Add(new Coord(x + 1, y + 1));
        // Diagonal Up Left
        if (IsInBounds(x - 1, y - 1))
            group.Add(new Coord(x - 1, y - 1));
        // Diagonal Down Left
        if (IsInBounds(x + 1, y - 1))
            group.Add(new Coord(x + 1, y - 1));

        coords.Add(group);

        return coords;
    }

    public List<string> GetAdjacentStrings(string targetLetter, int totalDistance, bool part2Flag)
    {
        var adjacentStrings = new List<string>();

        for (int i = 0; i < _puzzle.Count; i++)
        {
            for (int j = 0; j < _puzzle[i].Count; j++)
            {
                if (_puzzle[i][j] == targetLetter)
                {
                    List<List<Coord>> adjacentCoordGroups;
                    if (part2Flag)
                    {
                        adjacentCoordGroups = GetXCoordGroups(i, j);
                    }
                    else
                    {
                        adjacentCoordGroups = GetAdjacentCoordGroups(i, j, totalDistance);
                    }

                    foreach (var group in adjacentCoordGroups)
                    {
                        var groupStr = string.Join("", group.Select(c => _puzzle[c.X][c.Y]).ToArray());
                        adjacentStrings.Add(groupStr);
                    }
                }
            }
        }

        return adjacentStrings;
    }

    public bool IsValidXString(string val)
    {
        return (
            val == "ASSMM" ||
            val == "AMSMS" ||
            val == "ASMSM" ||
            val == "AMMSS"
        );
    }
}

public class Day4 : IDay
{
    public string SolvePart1(string input)
    {
        var puzzle = new Puzzle(input);
        var adjacentStrings = puzzle.GetAdjacentStrings("X", 4, false);
        var matches = adjacentStrings.Count(s => s == "XMAS" || s == "SAMX");
        return matches.ToString();
    }

    public string SolvePart2(string input)
    {
        var puzzle = new Puzzle(input);
        var adjacentStrings = puzzle.GetAdjacentStrings("A", 1, true);
        var matches = adjacentStrings.Count(puzzle.IsValidXString);
        return matches.ToString();
    }
}