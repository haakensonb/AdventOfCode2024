using AdventOfCode2024.Day12;

namespace Tests;

public class Day12Test
{

    [Fact]
    public void TestPart1Example1()
    {
        var input = "AAAA\nBBCD\nBBCC\nEEEC";
        var day12 = new Day12();
        var answer = day12.SolvePart1(input);
        var expected = "140";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestPart1Example2()
    {
        var input = "RRRRIICCFF\nRRRRIICCCF\nVVRRRCCFFF\nVVRCCCJFFF\nVVVVCJJCFE\nVVIVCCJJEE\nVVIIICJJEE\nMIIIIIJJEE\nMIIISIJEEE\nMMMISSJEEE";
        var day12 = new Day12();
        var answer = day12.SolvePart1(input);
        var expected = "1930";
        Assert.Equal(expected, answer);
    }

}