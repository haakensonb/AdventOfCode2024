using AdventOfCode2024.Day13;

namespace Tests;

public class Day13Test
{
    private readonly string Input1 =
        @"Button A: X+94, Y+34
Button B: X+22, Y+67
Prize: X=8400, Y=5400

Button A: X+26, Y+66
Button B: X+67, Y+21
Prize: X=12748, Y=12176

Button A: X+17, Y+86
Button B: X+84, Y+37
Prize: X=7870, Y=6450

Button A: X+69, Y+23
Button B: X+27, Y+71
Prize: X=18641, Y=10279";

    [Fact]
    public void TestPart1()
    {
        var day13 = new Day13();
        var answer = day13.SolvePart1(Input1);
        var expected = "480";
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
