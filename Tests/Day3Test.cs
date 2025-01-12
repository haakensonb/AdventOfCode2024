using AdventOfCode2024;

namespace Tests;

public class Day3Test
{
    private static readonly string Input1 = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

    [Fact]
    public void TestPart1()
    {
        var day3 = new Day3();
        var answer = day3.SolvePart1(Input1);
        var expected = "161";
        Assert.Equal(expected, answer);
    }

}