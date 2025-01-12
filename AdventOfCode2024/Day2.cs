using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2024;

public class Report
{
    private List<int> levels;

    public Report(string input)
    {
        this.levels = input.Split(" ").Select(int.Parse).ToList();
    }

    public bool IsSafe()
    {
        // "Safe" conditions:
        // 1. A level is either all increasing OR all decreasing.
        // 2. Any two adjacent levels differ by at least 1 and at most 3.
        var adjacentDifferences = new List<int>();
        for (var i = 1; i < levels.Count; i++)
        {
            var prev = this.levels[i - 1];
            var curr = this.levels[i];
            adjacentDifferences.Add(curr - prev);
        }
        var allPositive = adjacentDifferences.All(d => d > 0);
        var allNegative = adjacentDifferences.All(d => d < 0);
        var withinDiffRange = adjacentDifferences.All(d => Math.Abs(d) > 0 && Math.Abs(d) <= 3);
        return (allPositive || allNegative) && withinDiffRange;
    }
}

public class Day2 : IDay
{
    public string SolvePart1(string input)
    {
        var reportsInputLines = input.Split("\n");
        var reports = reportsInputLines.Select(line => new Report(line)).ToList();
        return reports.Select(report => report.IsSafe()).Count(isSafe => isSafe == true).ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}