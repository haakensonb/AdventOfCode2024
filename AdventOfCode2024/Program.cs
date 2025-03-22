namespace AdventOfCode2024;

using System.Diagnostics;

class Program
{
    private static readonly OrderedDictionary<string, string> DaysMapping = new OrderedDictionary<string, string>
    {
        { "1", "Day1" }, { "2", "Day2" }, { "3", "Day3" }, { "4", "Day4" }, { "5", "Day5" }, { "6", "Day6" },
        { "7", "Day7" }, { "8", "Day8" }, { "9", "Day9" }, { "10", "Day10" }
    };

    private static readonly string BaseNamespace = "AdventOfCode2024";

    public static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2024");
        var outputLines = new List<OutputLine>();
        
        foreach (var day in DaysMapping)
        {
            Console.WriteLine($"Running Day {day.Key}...");
            var dayNamespace = $"{BaseNamespace}.{day.Value}";
            var dayClassname = $"{dayNamespace}.{day.Value}";
            Type? t = Type.GetType(dayClassname);
            if (t == null)
            {
                Console.WriteLine($"Day {day.Key} has not been registered.");
            }
            else
            {
                var path = Path.Combine(Environment.CurrentDirectory, @"Data/", $"input_{day.Key}.txt");
                var dataInput = File.ReadAllText(path);
                IDay? dayObj = (IDay)Activator.CreateInstance(t)!;

                Stopwatch sw = new Stopwatch();
                sw.Start();
                var part1 = dayObj.SolvePart1(dataInput);
                sw.Stop();
                var part1ms = sw.ElapsedMilliseconds;

                sw.Restart();
                var part2 = dayObj.SolvePart2(dataInput);
                sw.Stop();
                var part2ms = sw.ElapsedMilliseconds;
                
                outputLines.Add(new OutputLine(day.Key, part1, part1ms, part2, part2ms));
            }
        }

        WriteOutputLines(outputLines);
        
    }

    private static void WriteOutputLines(List<OutputLine> outputLines)
    {
        Console.WriteLine(OutputLine.BarLine());
        Console.WriteLine(OutputLine.Header());
        Console.WriteLine(OutputLine.BarLine());
        foreach (var line in outputLines)
        {
            Console.WriteLine(line.ToString());
            Console.WriteLine(OutputLine.BarLine());
        }
    }
}