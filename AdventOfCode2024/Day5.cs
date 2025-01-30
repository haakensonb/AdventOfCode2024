namespace AdventOfCode2024;

public record UpdateLine
{
    public required List<int> Nums { get; init; }

    public int GetMiddleNum()
    {
        var index = Nums.Count / 2;
        return Nums[index];
    }
}

public class Puzzle5
{
    private Dictionary<int, HashSet<int>> _rules;
    private List<UpdateLine> _updateLines;

    private Dictionary<int, HashSet<int>> ParseRules(string rulesStr)
    {
        var result = new Dictionary<int, HashSet<int>>();
        var ruleLines = rulesStr.Split("\n");
        foreach (var line in ruleLines)
        {
            var splitRuleLine = line.Split("|");
            var x = int.Parse(splitRuleLine[0]);
            var y = int.Parse(splitRuleLine[1]);
            if (result.ContainsKey(x))
            {
                result[x].Add(y);
            }
            else
            {
                result[x] = new HashSet<int> { y };
            }
        }

        return result;
    }

    private List<UpdateLine> ParseUpdates(string updatesStr)
    {
        var result = new List<UpdateLine>();
        var updateLines = updatesStr.Split("\n");
        foreach (var line in updateLines)
        {
            var formatedLine = line.Split(",").Select(int.Parse).ToList();
            var updateLine = new UpdateLine { Nums = formatedLine };
            result.Add(updateLine);
        }

        return result;
    }

    public Puzzle5(string input)
    {
        var splitInput = input.Split("\n\n");
        _rules = ParseRules(splitInput[0]);
        _updateLines = ParseUpdates(splitInput[1]);
    }

    private bool IsValidUpdate(UpdateLine updateLine)
    {
        var alreadySeen = new HashSet<int>();
        foreach (var num in updateLine.Nums)
        {
            if (_rules.ContainsKey(num))
            {
                var numMustComeBefore = _rules[num];
                var intersect = alreadySeen.Intersect(numMustComeBefore);
                if (intersect.Any())
                {
                    return false;
                }
            }

            alreadySeen.Add(num);
        }

        return true;
    }

    public List<UpdateLine> GetValidUpdates()
    {
        return _updateLines.Where(IsValidUpdate).ToList();
    }
}

public class Day5 : IDay
{
    public string SolvePart1(string input)
    {
        var puzzle = new Puzzle5(input);
        var validUpdates = puzzle.GetValidUpdates();
        return validUpdates.Select(u => u.GetMiddleNum()).Sum().ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}