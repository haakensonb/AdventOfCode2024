using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public enum InstructionType
{
    Multiply,
    Unknown
}

public record Instruction
{
    private int X;
    private int Y;
    private InstructionType Type;

    public Instruction(string instruction)
    {
        if (instruction.StartsWith("mul"))
        {
            this.Type = InstructionType.Multiply;
        }
        else
        {
            this.Type = InstructionType.Unknown;
        }

        var regex = new Regex(@"\d+");
        var matches = regex.Matches(instruction);
        this.X = int.Parse(matches[0].Value);
        this.Y = int.Parse(matches[1].Value);
    }

    public int Calculate()
    {
        return this.Type switch
        {
            InstructionType.Multiply => this.X * this.Y,
            InstructionType.Unknown => 0,
        };
    }
}

public class Day3 : IDay
{
    private int SumInputLine(string line)
    {
        var regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
        var matches = regex.Matches(line);
        var instructions = matches.Select(m => new Instruction(m.Value));
        return instructions.Select(x => x.Calculate()).Sum();
    }

    public string SolvePart1(string input)
    {
        var lines = input.Split("\n").ToList();
        return lines.Select(SumInputLine).Sum().ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}