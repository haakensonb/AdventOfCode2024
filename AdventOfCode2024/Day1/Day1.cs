namespace AdventOfCode2024.Day1;

public class Day1 : IDay
{
    public string SolvePart1(string input)
    {
        var elfLocation = new ElfLocation(input);
        var distances = elfLocation.GetDistances();
        return distances.Sum().ToString();
    }

    public string SolvePart2(string input)
    {
        var elfLocation = new ElfLocation(input);
        var similarityScores = elfLocation.GetSimilarityScores();
        return similarityScores.Sum().ToString();
    }
}