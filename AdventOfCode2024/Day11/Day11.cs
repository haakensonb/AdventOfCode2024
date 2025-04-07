namespace AdventOfCode2024.Day11;

public record Puzzle
{
    private List<long> _stones;

    public Puzzle(string input)
    {
        _stones = input.Split(" ").Select(long.Parse).ToList();
    }

    private (long left, long right) SplitStone(long stone)
    {
        var stoneStr = stone.ToString();
        var left = long.Parse(stoneStr.Substring(0, stoneStr.Length / 2));
        var right = long.Parse(stoneStr.Substring(stoneStr.Length / 2));
        return (left, right);
    }

    private void SingleBlink()
    {
        // If the stone is engraved with the number 0, it is replaced by a stone engraved with the number 1.
        
        // If the stone is engraved with a number that has an even number of digits, it is replaced by two stones.
        
        // If none of the other rules apply, the stone is replaced by a new stone; the old stone's number multiplied by
        // 2024 is engraved on the new stone.
        var stoneCount = _stones.Count;
        for (var i = 0; i < stoneCount; i++)
        {
            var stone = _stones[i];
            if (stone == 0)
            {
                _stones[i] = 1;
            } else if (stone.ToString().Length % 2 == 0)
            {
                var splitStones = SplitStone(stone);
                _stones.Insert(i, splitStones.right);
                _stones.Insert(i, splitStones.left);
                // Need to adjust index/count to account for inserting/removing during loop
                _stones.RemoveAt(i + 2);
                stoneCount += 1;
                i += 1;
            }
            else
            {
                _stones[i] *= 2024;
            }
        }
    }

    public void Blink(int numOfBlinks)
    {
        for (var i = 0; i < numOfBlinks; i++)
        {
            SingleBlink();
        }
    }

    public long GetNumOfStones()
    {
        return _stones.Count;
    }
}

public class Day11 : IDay
{
    public string SolvePart1(string input)
    {
        var puzzle = new Puzzle(input);
        puzzle.Blink(25);
        return puzzle.GetNumOfStones().ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}