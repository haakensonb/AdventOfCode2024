using AdventOfCode2024.Day3;

namespace Tests;

public class Day3Test
{
    private static readonly string Input1 = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

    private static readonly string Input2 =
        "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

    private static readonly string Input3 = "mul(1,2)don't()badstuffmul(30,10)\nstillbadmul(2,100)do()mul(2,4)";

    [Fact]
    public void TestPart1()
    {
        var day3 = new Day3();
        var answer = day3.SolvePart1(Input1);
        var expected = "161";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestPart2()
    {
        var day3 = new Day3();
        var answer = day3.SolvePart2(Input2);
        var expected = "48";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestPart2Edge()
    {
        var day3 = new Day3();
        var answer = day3.SolvePart2(Input3);
        var expected = "10";
        Assert.Equal(expected, answer);
    }
}