using AdventOfCode2024.Day9;

namespace Tests;

public class Day9Test
{
    private static readonly string Input1 = "2333133121414131402";

    [Fact]
    public void TestPart1()
    {
        var day9 = new Day9();
        var answer = day9.SolvePart1(Input1);
        var expected = "1928";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestPart2()
    {
        var day9 = new Day9();
        var answer = day9.SolvePart2(Input1);
        var expected = "2858";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestEdgeCase1()
    {
        var day9 = new Day9();
        var answer = day9.SolvePart1("11221");
        var expected = "7";
        Assert.Equal(expected, answer);
    }
}