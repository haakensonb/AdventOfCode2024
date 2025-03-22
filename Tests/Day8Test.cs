using AdventOfCode2024.Day8;

namespace Tests;

public class Day8Test
{
    private static readonly string Input1 = "............\n........0...\n.....0......\n.......0....\n....0.......\n......A.....\n............\n............\n........A...\n.........A..\n............\n............";

    [Fact]
    public void TestPart1()
    {
        var day8 = new Day8();
        var answer = day8.SolvePart1(Input1);
        var expected = "14";
        Assert.Equal(expected, answer);
    }
    
    [Fact]
    public void TestPart2()
    {
        var day8 = new Day8();
        var answer = day8.SolvePart2(Input1);
        var expected = "34";
        Assert.Equal(expected, answer);
    }
}