namespace AdventOfCode2024.Day9;

public class Day9 : IDay
{
    public string SolvePart1(string input)
    {
        var puzzle = new Puzzle(input);
        puzzle.MoveFileBlocks();
        return puzzle.Checksum().ToString();
    }

    public string SolvePart2(string input)
    {
        var puzzle = new Puzzle(input);
        puzzle.MoveFileBlocksWithoutFrag();
        return puzzle.Checksum().ToString();
    }
}