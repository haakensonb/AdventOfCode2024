namespace AdventOfCode2024.Day7;

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

        return total;
    }

    private long ConcatNums(long a, long b)
    {
        return long.Parse(a.ToString() + b.ToString());
    }

    // Needs refactor
    private long GenPossiblePart2(long total, int i)
    {
        if (i >= Values.Count)
        {
            PossibleValues.Add(total);
            return total;
        }

        GenPossiblePart2(total + Values[i], i + 1);

        if (total == 0)
        {
            GenPossiblePart2(1 * Values[i], i + 1);
        }
        else
        {
            GenPossiblePart2(total * Values[i], i + 1);
        }

        GenPossiblePart2(ConcatNums(total, Values[i]), i + 1);

        return total;
    }

    public bool IsValid()
    {
        GenPossible(0, 0);
        return PossibleValues.Contains(TargetValue);
    }

    public bool IsValidPart2()
    {
        GenPossiblePart2(0, 0);
        return PossibleValues.Contains(TargetValue);
    }
}