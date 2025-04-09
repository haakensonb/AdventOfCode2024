namespace AdventOfCode2024.Day11;

public record Arg(long stone, int blinkLevel);

public record Puzzle
{
    private List<long> _stones;

    private Dictionary<Arg, long> _cache;

    public Puzzle(string input)
    {
        _stones = input.Split(" ").Select(long.Parse).ToList();
        _cache = new Dictionary<Arg, long>();
    }

    private (long left, long right) SplitStone(long stone)
    {
        var stoneStr = stone.ToString();
        var left = long.Parse(stoneStr.Substring(0, stoneStr.Length / 2));
        var right = long.Parse(stoneStr.Substring(stoneStr.Length / 2));
        return (left, right);
    }

    private long ExpandStone(long originalStone, int totalBlinks)
    {
        // If the stone is engraved with the number 0, it is replaced by a stone engraved with the number 1.
        
        // If the stone is engraved with a number that has an even number of digits, it is replaced by two stones.
        
        // If none of the other rules apply, the stone is replaced by a new stone; the old stone's number multiplied by
        // 2024 is engraved on the new stone.

        long recurse(Arg arg)
        {
            // Memoization
            if (_cache.TryGetValue(arg, out long val))
                return val;

            // Base case
            if (arg.blinkLevel == 0)
                return 1;

            var lowerBlinkLevel = arg.blinkLevel - 1;

            if (arg.stone == 0){
                _cache[arg] = recurse(new Arg(1, lowerBlinkLevel));
            } else if (arg.stone.ToString().Length % 2 == 0){
                var (left, right) = SplitStone(arg.stone);
                var leftArg = new Arg(left, lowerBlinkLevel);
                var rightArg = new Arg(right, lowerBlinkLevel);
                _cache[arg] = recurse(leftArg) + recurse(rightArg);
            } else {
                _cache[arg] = recurse(new Arg(arg.stone * 2024, lowerBlinkLevel));
            }

            return _cache[arg];
            
        }

        var count = recurse(new Arg(originalStone, totalBlinks));
        
        return count;
    }

    public long Blink(int numOfBlinks)
    {
        return _stones.Select(stone => ExpandStone(stone, numOfBlinks)).Sum();
    }

}

public class Day11 : IDay
{
    public string SolvePart1(string input)
    {
        var puzzle = new Puzzle(input);
        var numOfStones = puzzle.Blink(25);
        return numOfStones.ToString();
    }

    public string SolvePart2(string input)
    {
        var puzzle = new Puzzle(input);
        var numOfStones = puzzle.Blink(75);
        return numOfStones.ToString();
    }
}