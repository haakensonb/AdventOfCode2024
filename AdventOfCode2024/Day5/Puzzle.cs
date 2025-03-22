namespace AdventOfCode2024.Day5;

public class Puzzle
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

    public Puzzle(string input)
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

    public UpdateLine GetFixedUpdate(UpdateLine updateLine)
    {
        var newUpdateLine = new UpdateLine { Nums = updateLine.Nums };
        // Probably a better way to do this
        while (!IsValidUpdate(newUpdateLine))
        {
            for (int i = 0; i < newUpdateLine.Nums.Count; i++)
            {
                var num = newUpdateLine.Nums[i];
                if (_rules.ContainsKey(num))
                {
                    var set = _rules[num];
                    foreach (var set_val in set)
                    {
                        var beforeIdx = newUpdateLine.Nums.IndexOf(set_val);
                        if (beforeIdx > -1 && beforeIdx < i)
                        {
                            // Swap
                            var temp = newUpdateLine.Nums[beforeIdx];
                            newUpdateLine.Nums[beforeIdx] = newUpdateLine.Nums[i];
                            newUpdateLine.Nums[i] = temp;
                        }
                    }
                }
            }
        }

        return newUpdateLine;
    }

    public List<UpdateLine> GetValidUpdates()
    {
        return _updateLines.Where(IsValidUpdate).ToList();
    }

    public List<UpdateLine> GetInvalidUpdates()
    {
        return _updateLines.Where(u => !IsValidUpdate(u)).ToList();
    }
}
