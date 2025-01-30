using AdventOfCode2024;

namespace Tests;

public class Day5Test
{
    private static readonly string Input1 =
        "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13\n\n75,47,61,53,29\n97,61,53,29,13\n75,29,13\n75,97,47,61,53\n61,13,29\n97,13,75,29,47";

    [Fact]
    public void TestPart1()
    {
        var day5 = new Day5();
        var answer = day5.SolvePart1(Input1);
        var expected = "143";
        Assert.Equal(expected, answer);
    }
}