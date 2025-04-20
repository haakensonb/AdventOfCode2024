using System.Text.RegularExpressions;

public record Machine
{
    public int Ax;
    public int Ay;
    public int Bx;
    public int By;
    public int PrizeX;
    public int PrizeY;
    public long PrizeXPart2;
    public long PrizeYPart2;

    public Machine(string input)
    {
        InitVals(input);
    }

    public (long NumButtonPressesA, long NumButtonPressesB) TryGetNumButton(long prizeX, long prizeY)
    {
        // A = number of A button presses
        // B = number of B button presses
        // Ax(A) + Bx(B) = prizeX
        // Ay(A) + By(B) = prizeY
        // System of 2 equations with 2 unknowns.
        // Solve first equation for A then plug in to second equation to get B.
        // Use B to get A.
        var BTopHalfEq = (prizeY * Ax) - (Ay * prizeX);
        var BBottomHalfEq = (Ax * By) - (Ay * Bx);
        // If the bottom half doesn't divide the top half evenly (with no remainder)
        // then B would be a floating point number which doesn't make sense.
        // It isn't possible to press a button a fractional amount of times, it can only be a whole number,
        // so there isn't a solution.
        if (BTopHalfEq % BBottomHalfEq != 0)
            return (-1, -1);
        var B = BTopHalfEq / BBottomHalfEq;
        var ATopHalf = prizeX - (Bx * B);
        var ABottomHalf = Ax;
        if (ATopHalf % ABottomHalf != 0)
            return (-1, -1);
        var A = ATopHalf / ABottomHalf;
        return (A, B);
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
            PrizeXPart2 = PrizeX + 10000000000000;
            PrizeYPart2 = PrizeY + 10000000000000;
        }
        else
        {
            Ax = 0;
            Ay = 0;
            Bx = 0;
            By = 0;
            PrizeX = 0;
            PrizeY = 0;
            PrizeXPart2 = 0;
            PrizeYPart2 = 0;
        }
    }
}
