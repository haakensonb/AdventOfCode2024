namespace AdventOfCode2024.Day5;

public record UpdateLine
{
    public required List<int> Nums { get; init; }

    public int GetMiddleNum()
    {
        var index = Nums.Count / 2;
        return Nums[index];
    }
}