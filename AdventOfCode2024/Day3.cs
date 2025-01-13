using System.Text.RegularExpressions;

namespace AdventOfCode2024;

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

public class Day3 : IDay
{
    private int SumInputLine(string line)
    {
        var regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
        var matches = regex.Matches(line);
        var instructions = matches.Select(m => new Instruction(m.Value));
        return instructions.Select(x => x.Calculate()).Sum();
    }

    private string RemoveDisabledInstructions(string line)
    {
        // Need Singleline so that "." will match newlines, "don't()" needs to keep matching onto the newline
        var regex = new Regex(@"don\'t\(\).*?do\(\)|don\'t\(\).+$", RegexOptions.Singleline);
        var result = regex.Replace(line, string.Empty);
        return result;
    }

    public string SolvePart1(string input)
    {
        var lines = input.Split("\n").ToList();
        return lines.Select(SumInputLine).Sum().ToString();
    }

    public string SolvePart2(string input)
    {
        var line = RemoveDisabledInstructions(input);
        return line.Split("\n").Select(SumInputLine).Sum().ToString();
    }
}