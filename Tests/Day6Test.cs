using AdventOfCode2024;

namespace Tests;

public class Day6Test
{
    private static readonly string Input1 =
        "....#.....\n.........#\n..........\n..#.......\n.......#..\n..........\n.#..^.....\n........#.\n#.........\n......#...";

    [Fact]
    public void TestPart1()
    {
        var day6 = new Day6();
        var answer = day6.SolvePart1(Input1);
        var expected = "41";
        Assert.Equal(expected, answer);
    }
}