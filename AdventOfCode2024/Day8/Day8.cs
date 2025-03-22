namespace AdventOfCode2024.Day8;

public class Day8 : IDay
{
    private HashSet<Point> FindAntiNodes(AntennaMap antennaMap, Point point1, Point point2)
    {
        var antinodes = new HashSet<Point>();
        var dist = point1.Distance(point2);
        var antinode1 = point1.Add(dist.Negate());
        var antinode2 = point2.Add(dist);
        if (antennaMap.IsWithin(antinode1))
        {
            antinodes.Add(antinode1);
        }
        if (antennaMap.IsWithin(antinode2))
        {
            antinodes.Add(antinode2);
        }
        return antinodes;
    }
    
    private HashSet<Point> FindAllAntiNodes(AntennaMap antennaMap, Point point1, Point point2)
    {
        var antinodes = new HashSet<Point>();
        antinodes.Add(point1);
        antinodes.Add(point2);
        var dist = point1.Distance(point2);
        var negDist = dist.Negate();
        var antinode1 = point1.Add(negDist);
        var antinode2 = point2.Add(dist);
        while (antennaMap.IsWithin(antinode1))
        {
            antinodes.Add(antinode1);
            antinode1 = antinode1.Add(negDist);
        }
        while (antennaMap.IsWithin(antinode2))
        {
            antinodes.Add(antinode2);
            antinode2 = antinode2.Add(dist);
        }
        return antinodes;
    }

    private string Solve(string input, Func<AntennaMap, Point, Point, HashSet<Point>> antinodeFunc)
    {
        var antennaMap = new AntennaMap(input);
        var frequencyPoints = antennaMap.GetFrequencyPoints();
        var uniqueAntinodePoints = new HashSet<Point>();
        foreach (var frequency in frequencyPoints)
        {
            var points = frequency.Value;
            foreach (var point1 in points)
            {
                foreach (var point2 in points)
                {
                    if (!point1.Equals(point2))
                    {
                        var antinodes = antinodeFunc(antennaMap, point1, point2);
                        uniqueAntinodePoints.UnionWith(antinodes);
                    }
                }
            }
        }
        return uniqueAntinodePoints.Count.ToString();
    }
    
    public string SolvePart1(string input)
    {
        var antinodeFunc = FindAntiNodes;
        return Solve(input, antinodeFunc);
    }

    public string SolvePart2(string input)
    {
        var antinodeFunc = FindAllAntiNodes;
        return Solve(input, antinodeFunc);
    }
}