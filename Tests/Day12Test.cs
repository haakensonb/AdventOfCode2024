using AdventOfCode2024.Day12;

namespace Tests;

public class Day12Test
{

    private readonly string Input1 = "AAAA\nBBCD\nBBCC\nEEEC";
    private readonly string Input2 = "RRRRIICCFF\nRRRRIICCCF\nVVRRRCCFFF\nVVRCCCJFFF\nVVVVCJJCFE\nVVIVCCJJEE\nVVIIICJJEE\nMIIIIIJJEE\nMIIISIJEEE\nMMMISSJEEE";

    [Fact]
    public void TestPart1Example1()
    {
        var day12 = new Day12();
        var answer = day12.SolvePart1(Input1);
        var expected = "140";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestPart1Example2()
    {
        var day12 = new Day12();
        var answer = day12.SolvePart1(Input2);
        var expected = "1930";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestPart2Example1()
    {
        var day12 = new Day12();
        var answer = day12.SolvePart2(Input1);
        var expected = "80";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestPart2Example2()
    {
        var day12 = new Day12();
        var answer = day12.SolvePart2(Input2);
        var expected = "1206";
        Assert.Equal(expected, answer);
    }

}