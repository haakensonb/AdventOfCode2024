using System.Diagnostics;

namespace AdventOfCode2024;

class Program
{
    private static readonly OrderedDictionary<string, string> DaysMapping = new OrderedDictionary<string, string>
        { { "1", "Day1" }, { "2", "Day2" }, { "3", "Day3" }, { "4", "Day4" }, { "5", "Day5" } };

    private static readonly string Namespace = "AdventOfCode2024";

    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2024\n");
        foreach (var day in DaysMapping)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"Day {day.Key}");
            Type? t = Type.GetType(Namespace + "." + day.Value);
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
                Console.WriteLine($"\nPart 1: {dayObj.SolvePart1(dataInput)}");
                sw.Stop();
                Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds} ms");

                sw.Restart();
                Console.WriteLine($"\nPart 2: {dayObj.SolvePart2(dataInput)}");
                sw.Stop();
                Console.WriteLine($"Elapsed time: {sw.ElapsedMilliseconds} ms");
            }
        }
    }
}