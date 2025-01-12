using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2024;

public class Report
{
    private List<int> levels;

    public Report(string input)
    {
        this.levels = input.Split(" ").Select(int.Parse).ToList();
    }

    public bool isSafe()
    {
        return true;
    }
}

public class Day2 : IDay
{
    public string SolvePart1(string input)
    {
        var reportsInputLines = input.Split("\n");
        var reports = new List<Report>();
        foreach (var line in reportsInputLines)
        {
            reports.Add(new Report(line));
        }

        return reports.Select(report => report.isSafe()).Count(isSafe => true).ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}