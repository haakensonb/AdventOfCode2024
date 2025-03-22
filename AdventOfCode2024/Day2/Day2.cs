namespace AdventOfCode2024.Day2;

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
        var reportsInputLines = input.Split("\n");
        var reports = reportsInputLines.Select(line => new Report(line)).ToList();
        return reports.Select(report => report.IsSafeWithProblemDampener()).Count(isSafe => isSafe == true).ToString();
    }
}