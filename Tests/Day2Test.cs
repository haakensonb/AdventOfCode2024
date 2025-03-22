using AdventOfCode2024.Day2;

namespace Tests;

public class Day2Test
{
    private static readonly string Input1 = "7 6 4 2 1\n1 2 7 8 9\n9 7 6 2 1\n1 3 2 4 5\n8 6 4 4 1\n1 3 6 7 9";

    [Fact]
    public void TestPart1()
    {
        var day2 = new Day2();
        var answer = day2.SolvePart1(Input1);
        var expected = "2";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestPart2()
    {
        var day2 = new Day2();
        var answer = day2.SolvePart2(Input1);
        var expected = "4";
        Assert.Equal(expected, answer);
    }
}