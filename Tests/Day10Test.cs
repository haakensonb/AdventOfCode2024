using AdventOfCode2024;

namespace Tests;

public class Day10Test
{
    private static readonly string Input1 =
        "89010123\n78121874\n87430965\n96549874\n45678903\n32019012\n01329801\n10456732";

    [Fact]
    public void TestPart1()
    {
        var day10 = new Day10();
        var answer = day10.SolvePart1(Input1);
        var expected = "36";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestSimpleExample1()
    {
        var input = "10..9..\n2...8..\n3...7..\n4567654\n...8..3\n...9..2\n.....01";
        var day10 = new Day10();
        var answer = day10.SolvePart1(input);
        var expected = "3";
        Assert.Equal(expected, answer);
    }
}