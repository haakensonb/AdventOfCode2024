namespace AdventOfCode2024.Day4;

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