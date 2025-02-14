namespace AdventOfCode2024;

public record Equation
{
    public long TargetValue { get; init; }
    public List<long> Values { get; init; }

    public HashSet<long> PossibleValues { get; init; }

    public Equation(string line)
    {
        var split = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
        TargetValue = long.Parse(split[0]);
        Values = split[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
        PossibleValues = new HashSet<long>();
    }

    // This is pretty ugly...
    private long GenPossible(long total, int i)
    {
        if (i >= Values.Count)
        {
            PossibleValues.Add(total);
            return total;
        }

        GenPossible(total + Values[i], i + 1);
        if (total == 0)
        {
            GenPossible(1 * Values[i], i + 1);
        }
        else
        {
            GenPossible(total * Values[i], i + 1);
        }

        PossibleValues.Add(total);
        return total;
    }

    public bool IsValid()
    {
        GenPossible(0, 0);
        return PossibleValues.Contains(TargetValue);
    }
}

public class Day7 : IDay
{
    public string SolvePart1(string input)
    {
        var lines = input.Split("\n");
        return lines.Select(l => new Equation(l)).Where(e => e.IsValid()).Sum(e => e.TargetValue).ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}