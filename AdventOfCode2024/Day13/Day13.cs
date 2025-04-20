namespace AdventOfCode2024.Day13;

public class Day13 : IDay
{
    private int Cost((int NumButtonPressesA, int NumButtonPressesB) numPresses)
    {
        return (numPresses.NumButtonPressesA * 3) + numPresses.NumButtonPressesB;
    }

    public string SolvePart1(string input)
    {
        var machineStrs = input.Split("\n\n");
        return machineStrs
            .Select(ms => new Machine(ms))
            .Select(m => m.TryGetNumButton())
            .Where(numButton => numButton != (-1, -1))
            .Select(numButton => Cost(numButton))
            .Sum()
            .ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}
