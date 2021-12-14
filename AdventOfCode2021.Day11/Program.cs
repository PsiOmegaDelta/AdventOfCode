using AdventOfCode.Shared;
using AdventOfCode2021.Day11;

const string inputPath = "Day11Input.txt";
Console.WriteLine("Part One: " + File.ReadLines(inputPath).ToIntArrays().CalculatePartOne(100));
Console.WriteLine("Part Two: " + File.ReadLines(inputPath).ToIntArrays().CalculatePartTwo());
