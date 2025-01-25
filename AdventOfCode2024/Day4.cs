namespace AdventOfCode2024;

public class Day4 : IDay
{
    private string GetIfInBounds(List<List<string>> puzzle, int i, int j)
    {
        if ((i >= 0 && j >= 0) && (i < puzzle.Count && j < puzzle[i].Count))
        {
            return puzzle[i][j];
        }

        return "";
    }

    private List<string> GetAdjacentStrings(List<List<string>> puzzle)
    {
        var adjacentStrings = new List<string>();

        for (int i = 0; i < puzzle.Count; i++)
        {
            for (int j = 0; j < puzzle[i].Count; j++)
            {
                if (puzzle[i][j] == "X")
                {
                    // Messy and gross
                    // Up
                    var up = new List<string> { puzzle[i][j] };
                    up.Add(GetIfInBounds(puzzle, i - 1, j));
                    up.Add(GetIfInBounds(puzzle, i - 2, j));
                    up.Add(GetIfInBounds(puzzle, i - 3, j));
                    adjacentStrings.Add(string.Join("", up));
                    // Down
                    var down = new List<string> { puzzle[i][j] };
                    down.Add(GetIfInBounds(puzzle, i + 1, j));
                    down.Add(GetIfInBounds(puzzle, i + 2, j));
                    down.Add(GetIfInBounds(puzzle, i + 3, j));
                    adjacentStrings.Add(string.Join("", down));
                    // Left
                    var left = new List<string> { puzzle[i][j] };
                    left.Add(GetIfInBounds(puzzle, i, j - 1));
                    left.Add(GetIfInBounds(puzzle, i, j - 2));
                    left.Add(GetIfInBounds(puzzle, i, j - 3));
                    adjacentStrings.Add(string.Join("", left));
                    // Right
                    var right = new List<string> { puzzle[i][j] };
                    right.Add(GetIfInBounds(puzzle, i, j + 1));
                    right.Add(GetIfInBounds(puzzle, i, j + 2));
                    right.Add(GetIfInBounds(puzzle, i, j + 3));
                    adjacentStrings.Add(string.Join("", right));
                    // Diagonal Up Right
                    var diagUpRight = new List<string> { puzzle[i][j] };
                    diagUpRight.Add(GetIfInBounds(puzzle, i - 1, j + 1));
                    diagUpRight.Add(GetIfInBounds(puzzle, i - 2, j + 2));
                    diagUpRight.Add(GetIfInBounds(puzzle, i - 3, j + 3));
                    adjacentStrings.Add(string.Join("", diagUpRight));
                    // Diagonal Down Right
                    var diagDownRight = new List<string> { puzzle[i][j] };
                    diagDownRight.Add(GetIfInBounds(puzzle, i + 1, j + 1));
                    diagDownRight.Add(GetIfInBounds(puzzle, i + 2, j + 2));
                    diagDownRight.Add(GetIfInBounds(puzzle, i + 3, j + 3));
                    adjacentStrings.Add(string.Join("", diagDownRight));
                    // Diagonal Up Left
                    var diagUpLeft = new List<string> { puzzle[i][j] };
                    diagUpLeft.Add(GetIfInBounds(puzzle, i - 1, j - 1));
                    diagUpLeft.Add(GetIfInBounds(puzzle, i - 2, j - 2));
                    diagUpLeft.Add(GetIfInBounds(puzzle, i - 3, j - 3));
                    adjacentStrings.Add(string.Join("", diagUpLeft));
                    // Diagonal Down Left
                    var diagDownLeft = new List<string> { puzzle[i][j] };
                    diagDownLeft.Add(GetIfInBounds(puzzle, i + 1, j - 1));
                    diagDownLeft.Add(GetIfInBounds(puzzle, i + 2, j - 2));
                    diagDownLeft.Add(GetIfInBounds(puzzle, i + 3, j - 3));
                    adjacentStrings.Add(string.Join("", diagDownLeft));
                }
            }
        }

        return adjacentStrings;
    }

    public string SolvePart1(string input)
    {
        List<List<string>> puzzle = new List<List<string>>();
        var lines = input.Split("\n").ToList();
        foreach (var line in lines)
        {
            var splitLine = line.Select(c => c.ToString()).ToList();
            puzzle.Add(splitLine);
        }

        var adjacentStrings = GetAdjacentStrings(puzzle);
        var matches = adjacentStrings.Count(s => s == "XMAS" || s == "SAMX");
        return matches.ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}