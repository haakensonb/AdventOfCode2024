using AdventOfCode2024.Day11;

namespace Tests;

public class Day11Test
{
    private static readonly string Input1 = "125 17";

    [Fact]
    public void TestPart1()
    {
        var day11 = new Day11();
        var answer = day11.SolvePart1(Input1);
        var expected = "55312";
        Assert.Equal(expected, answer);
    }

}