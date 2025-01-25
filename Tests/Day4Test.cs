using AdventOfCode2024;

namespace Tests;

public class Day4Test
{
    private static readonly string Input1 = "MMMSXXMASM\nMSAMXMSMSA\nAMXSXMAAMM\nMSAMASMSMX\nXMASAMXAMM\nXXAMMXXAMA\nSMSMSASXSS\nSAXAMASAAA\nMAMMMXMMMM\nMXMXAXMASX";

    [Fact]
    public void TestPart1()
    {
        var day4 = new Day4();
        var answer = day4.SolvePart1(Input1);
        var expected = "18";
        Assert.Equal(expected, answer);
    }
}