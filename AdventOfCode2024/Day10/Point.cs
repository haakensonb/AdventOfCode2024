namespace AdventOfCode2024.Day10;

public record Point(int X, int Y)
{
    public override string ToString() => $"({X}, {Y})";
}