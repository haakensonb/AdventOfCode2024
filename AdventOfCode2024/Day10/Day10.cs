namespace AdventOfCode2024.Day10;

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