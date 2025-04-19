using AdventOfCode2024.Day13;

namespace Tests;

public class Day13Test
{
    private readonly string Input1 = "";

    [Fact]
    public void TestPart1()
    {
        var day13 = new Day13();
        var answer = day13.SolvePart1(Input1);
        var expected = "";
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void TestMachineParse()
    {
        var input = "Button A: X+94, Y+34\nButton B: X+22, Y+67\nPrize: X=8400, Y=5400";
        var machine = new Machine(input);
        Assert.Equal(94, machine.Ax);
        Assert.Equal(34, machine.Ay);
        Assert.Equal(22, machine.Bx);
        Assert.Equal(67, machine.By);
        Assert.Equal(8400, machine.PrizeX);
        Assert.Equal(5400, machine.PrizeY);
    }

    [Fact]
    public void TestMachineButtonPresses()
    {
        var input = "Button A: X+94, Y+34\nButton B: X+22, Y+67\nPrize: X=8400, Y=5400";
        var machine = new Machine(input);
        (int NumButtonPressesA, int NumButtonPressesB)? result = machine.TryGetNumButton();
        var expected = (80, 40);
        Assert.Equal(expected, result);
    }
}
