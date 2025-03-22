namespace AdventOfCode2024.Day7;

public class Day7 : IDay
{
    public string SolvePart1(string input)
    {
        var lines = input.Split("\n");
        return lines.Select(l => new Equation(l)).Where(e => e.IsValid()).Sum(e => e.TargetValue).ToString();
    }

    public string SolvePart2(string input)
    {
        var lines = input.Split("\n");
        return lines.Select(l => new Equation(l)).Where(e => e.IsValidPart2()).Sum(e => e.TargetValue).ToString();
    }
}