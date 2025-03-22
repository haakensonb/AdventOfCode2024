namespace AdventOfCode2024.Day2;

public class Report
{
    private List<int> levels;

    public Report(List<int> levels)
    {
        this.levels = levels;
    }

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

    public bool IsSafeWithProblemDampener()
    {
        var allPossibleReports = new List<Report>();
        // Generate all possible reports with one level removed
        for (var i = 0; i < levels.Count; i++)
        {
            var newLevels = new List<int>();
            for (var j = 0; j < levels.Count; j++)
            {
                if (j != i)
                {
                    newLevels.Add(levels[j]);
                }
            }
            allPossibleReports.Add(new Report(newLevels));
        }
        var hasSafePossibleReport = allPossibleReports.Any(r => r.IsSafe());
        return hasSafePossibleReport;
    }
}
