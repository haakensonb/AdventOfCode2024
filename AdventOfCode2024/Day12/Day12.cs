namespace AdventOfCode2024.Day12;


public class Day12 : IDay
{
    public string SolvePart1(string input)
    {
        var garden = new Garden(input);
        return garden.GetRegions().Select(r => r.GetPrice()).Sum().ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}