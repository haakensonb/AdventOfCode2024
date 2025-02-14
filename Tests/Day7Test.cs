using AdventOfCode2024;

namespace Tests;

public class Day7Test
{
    private static readonly string Input1 =
        "190: 10 19\n3267: 81 40 27\n83: 17 5\n156: 15 6\n7290: 6 8 6 15\n161011: 16 10 13\n192: 17 8 14\n21037: 9 7 18 13\n292: 11 6 16 20";

    [Fact]
    public void TestPart1()
    {
        var day7 = new Day7();
        var answer = day7.SolvePart1(Input1);
        var expected = "3749";
        Assert.Equal(expected, answer);
    }
}