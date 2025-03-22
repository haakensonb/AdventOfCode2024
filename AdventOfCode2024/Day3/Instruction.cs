namespace AdventOfCode2024.Day3;

using System.Text.RegularExpressions;

public record Instruction
{
    private int X;
    private int Y;

    public Instruction(string instruction)
    {
        var regex = new Regex(@"\d+");
        var matches = regex.Matches(instruction);
        this.X = int.Parse(matches[0].Value);
        this.Y = int.Parse(matches[1].Value);
    }

    public int Calculate()
    {
        return this.X * this.Y;
    }
}
