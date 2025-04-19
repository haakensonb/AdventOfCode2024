using System.Text.RegularExpressions;
using AdventOfCode2024.Common;

public record Machine
{
    public int Ax;
    public int Ay;
    public int Bx;
    public int By;
    public int PrizeX;
    public int PrizeY;

    private Point[,] _arr;
    private int _size = 100;

    public Machine(string input)
    {
        InitVals(input);
        CreateSolutionArr();
    }

    private void CreateSolutionArr()
    {
        var _size = 100;
        _arr = new Point[_size, _size];

        _arr[0, 0] = new Point(0, 0);
        // Fill first row
        for (var j = 1; j < _size; j++)
        {
            var newY = (Ay * j) + (By * j);
            _arr[0, j] = new Point(0, newY);
        }
        // Fill first column
        for (var i = 1; i < _size; i++)
        {
            var newX = (Ax * i) + (Bx * i);
            _arr[i, 0] = new Point(newX, 0);
        }
        // Fill remaining
        for (var i = 1; i < _size; i++)
        {
            for (var j = 1; j < _size; j++)
            {
                var x = _arr[i, j - 1].X;
                var y = _arr[i - 1, j].Y;
                _arr[i, j] = new Point(x, y);
            }
        }
    }

    public (int NumButtonPressesA, int NumButtonPressesB)? TryGetNumButton()
    {
        for (var i = 1; i < _size; i++)
        {
            for (var j = 1; j < _size; j++)
            {
                if (_arr[i, j].X == PrizeX && _arr[i, j].Y == PrizeY)
                    return (i, j);
            }
        }
        return null;
    }

    private void InitVals(string input)
    {
        var pattern =
            @"A:\sX\+(?<Ax>\d+).*Y+\+(?<Ay>\d+).*B:\sX\+(?<Bx>\d+).*Y\+(?<By>\d+).*X=(?<PrizeX>\d+).*Y=(?<PrizeY>\d+)";
        var regex = new Regex(pattern, RegexOptions.Singleline);

        var match = regex.Match(input);

        if (match.Success)
        {
            Ax = int.Parse(match.Groups["Ax"].Value);
            Ay = int.Parse(match.Groups["Ay"].Value);
            Bx = int.Parse(match.Groups["Bx"].Value);
            By = int.Parse(match.Groups["By"].Value);
            PrizeX = int.Parse(match.Groups["PrizeX"].Value);
            PrizeY = int.Parse(match.Groups["PrizeY"].Value);
        }
        else
        {
            Ax = 0;
            Ay = 0;
            Bx = 0;
            By = 0;
            PrizeX = 0;
            PrizeY = 0;
        }
    }
}
