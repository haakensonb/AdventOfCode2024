namespace AdventOfCode2024;

public record OutputLine(string day, string part1, long part1ms, string part2, long part2ms)
{
    private static readonly string lineFormat = "| {0, -5} | {1, -20} | {2, -16} | {3, -20} | {4, -16} |";
    
    public override string ToString()
    {
        return string.Format(lineFormat, day, part1, part1ms, part2, part2ms);
    }

    public static string Header()
    {
        return string.Format(lineFormat, "Day", "Part 1", "Part 1 Time (ms)", "Part 2", "Part 2 Time (ms)");
    }

    public static string BarLine()
    {
        return new string('-', Header().Length);
    }
}