namespace AdventOfCode2024;

public class Puzzle9
{
    private List<string> _expandedDiskMap;

    public Puzzle9(string diskMapInput)
    {
        _expandedDiskMap = ExpandDiskMap(diskMapInput);
        MoveFileBlocks();
    }

    private List<string> ExpandDiskMap(string diskMap)
    {
        var expandedDiskMap = new List<string>();
        var idCounter = 0;
        for (var i = 0; i < diskMap.Length; i++)
        {
            var numOfChars = int.Parse(diskMap.Substring(i, 1));
            if (i % 2 == 0)
            {
                for (var j = 0; j < numOfChars; j++)
                {
                    expandedDiskMap.Add(idCounter.ToString());
                }

                idCounter += 1;
            }
            else
            {
                for (var j = 0; j < numOfChars; j++)
                {
                    expandedDiskMap.Add(".");
                }
            }
        }

        return expandedDiskMap;
    }

    private void MoveFileBlocks()
    {
        var startIdx = _expandedDiskMap.IndexOf(".");
        var endIdx = _expandedDiskMap.Count - 1;
        // Find first number starting from end of disk map
        while (_expandedDiskMap[endIdx].Equals("."))
        {
            endIdx -= 1;
        }

        // Move valid values from endIdx to startIdx until indexes overlap
        while (startIdx < endIdx)
        {
            while (!_expandedDiskMap[startIdx].Equals("."))
            {
                startIdx += 1;
            }

            while (_expandedDiskMap[endIdx].Equals("."))
            {
                endIdx -= 1;
            }

            // Need to check indexes again
            if (startIdx < endIdx)
            {
                _expandedDiskMap[startIdx] = _expandedDiskMap[endIdx];
                _expandedDiskMap[endIdx] = ".";
                startIdx += 1;
                endIdx -= 1;
            }
        }
    }

    public long Checksum()
    {
        long result = 0;
        for (var i = 0; i < _expandedDiskMap.Count; i++)
        {
            if (!_expandedDiskMap[i].Equals("."))
            {
                var val = int.Parse(_expandedDiskMap[i]);
                result += (val * i);
            }
        }

        return result;
    }
}

public class Day9 : IDay
{
    public string SolvePart1(string input)
    {
        var puzzle = new Puzzle9(input);
        return puzzle.Checksum().ToString();
    }

    public string SolvePart2(string input)
    {
        return "";
    }
}