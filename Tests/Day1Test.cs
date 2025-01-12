using AdventOfCode2024;

namespace Tests;

public class Day1Test
{
    private static readonly string Input1 = "3   4\n4   3\n2   5\n1   3\n3   9\n3   3";

    [Fact]
    public void TestPart1()
    {
        Day1 day1 = new Day1();
        var answer = day1.SolvePart1(Input1);
        var expected = "11";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestPart2()
    {
        Day1 day1 = new Day1();
        var answer = day1.SolvePart2(Input1);
        var expected = "31";
        Assert.Equal(expected, answer);
    }
}