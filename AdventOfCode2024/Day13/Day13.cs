namespace AdventOfCode2024.Day13;

public class Day13 : IDay
{
    private long Cost((long NumButtonPressesA, long NumButtonPressesB) numPresses)
    {
        return (numPresses.NumButtonPressesA * 3) + numPresses.NumButtonPressesB;
    }

    public string SolvePart1(string input)
    {
        var machineStrs = input.Split("\n\n");
        return machineStrs
            .Select(ms => new Machine(ms))
            .Select(m => m.TryGetNumButton(m.PrizeX, m.PrizeY))
            .Where(numButton => numButton != (-1, -1))
            .Select(Cost)
            .Sum()
            .ToString();
    }

    public string SolvePart2(string input)
    {
        var machineStrs = input.Split("\n\n");
        return machineStrs
            .Select(ms => new Machine(ms))
            .Select(m => m.TryGetNumButton(m.PrizeXPart2, m.PrizeYPart2))
            .Where(numButton => numButton != (-1, -1))
            .Select(Cost)
            .Sum()
            .ToString();
    }
}
