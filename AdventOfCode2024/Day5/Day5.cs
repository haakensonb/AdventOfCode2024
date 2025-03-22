namespace AdventOfCode2024.Day5;

public class Day5 : IDay
{
    public string SolvePart1(string input)
    {
        var puzzle = new Puzzle(input);
        var validUpdates = puzzle.GetValidUpdates();
        return validUpdates.Select(u => u.GetMiddleNum()).Sum().ToString();
    }

    public string SolvePart2(string input)
    {
        var puzzle = new Puzzle(input);
        var invalidUpdates = puzzle.GetInvalidUpdates();
        var fixedUpdates = new List<UpdateLine>();
        foreach (var u in invalidUpdates)
        {
            var fixedUpdate = puzzle.GetFixedUpdate(u);
            fixedUpdates.Add(fixedUpdate);
        }

        return fixedUpdates.Select(u => u.GetMiddleNum()).Sum().ToString();
    }
}