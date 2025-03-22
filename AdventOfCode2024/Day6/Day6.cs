namespace AdventOfCode2024.Day6;

using System.Text;

public class Day6 : IDay
{
    public string SolvePart1(string input)
    {
        var puzzleMap = new PuzzleMap(input);
        puzzleMap.PatrolSimulation();
        return puzzleMap.CountXs().ToString();
    }

    private List<PuzzleMap> GeneratePossiblePuzzleMapsWithObstructions(string initialInput)
    {
        var possiblePuzzleMaps = new List<PuzzleMap>();
        List<string> possibleInputs = [];
        var sb = new StringBuilder(initialInput);
        for (int i = 0; i < sb.Length; i++)
        {
            if (sb[i] == '.')
            {
                sb[i] = '#';
                possibleInputs.Add(sb.ToString());
                // Change back
                sb[i] = '.';
            }
        }

        foreach (var input in possibleInputs)
        {
            possiblePuzzleMaps.Add(new PuzzleMap(input));
        }

        return possiblePuzzleMaps;
    }

    public string SolvePart2(string input)
    {
        // Brute force
        var possiblePuzzleMaps = GeneratePossiblePuzzleMapsWithObstructions(input);
        var obstructedCount = 0;
        foreach (var puzzleMap in possiblePuzzleMaps)
        {
            var isObstructed = puzzleMap.IsMapObstructedSimulation();
            if (isObstructed)
                obstructedCount += 1;
        }

        return obstructedCount.ToString();
    }
}