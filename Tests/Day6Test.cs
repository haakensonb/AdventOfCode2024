﻿using AdventOfCode2024.Day6;

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

    [Fact]
    public void TestPart2()
    {
        var day6 = new Day6();
        var answer = day6.SolvePart2(Input1);
        var expected = "6";
        Assert.Equal(expected, answer);
    }
}