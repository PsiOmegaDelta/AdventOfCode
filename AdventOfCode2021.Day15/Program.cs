using AdventOfCode.Shared;
using AdventOfCode2021.Day15;

const string inputPath = "Day15Input.txt";
Console.WriteLine("2021 - Day 15");
Console.WriteLine("Part One: " + File.ReadLines(inputPath).ToIntArrays().CalculatePartOne());
Console.WriteLine("Part Two: " + File.ReadLines(inputPath).ToIntArrays().CalculatePartTwo());
