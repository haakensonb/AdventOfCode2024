namespace AdventOfCode2024.Day1;

public class ElfLocation
{
    private readonly List<int> _leftColumn = new List<int>();
    private readonly List<int> _rightColumn = new List<int>();

    public ElfLocation(string input)
    {
        var inputLines = input.Split('\n');
        foreach (var line in inputLines)
        {
            var splitLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var leftNum = int.Parse(splitLine[0]);
            var rightNum = int.Parse(splitLine[1]);
            _leftColumn.Add(leftNum);
            _rightColumn.Add(rightNum);
        }
    }

    private int CalcDistance(int leftNum, int rightNum)
    {
        return Math.Abs(leftNum - rightNum);
    }

    public List<int> GetDistances()
    {
        // Modify in place
        _leftColumn.Sort();
        _rightColumn.Sort();

        List<int> distances = new List<int>();
        for (int i = 0; i < _leftColumn.Count; i++)
        {
            distances.Add(CalcDistance(_leftColumn[i], _rightColumn[i]));
        }

        return distances;
    }

    public List<int> GetSimilarityScores()
    {
        List<int> similarityScores = new List<int>();

        foreach (var num in _leftColumn)
        {
            var rightSideCount = _rightColumn.Count(x => x == num);
            similarityScores.Add(num * rightSideCount);
        }

        return similarityScores;
    }
}
