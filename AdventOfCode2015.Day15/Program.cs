using AdventOfCode.Shared.Extensions;
using AdventOfCode2015.Day15;

const string inputPath = "Day15Input.txt";
Console.WriteLine("2015 - Day 15");
Console.WriteLine("Part One: " + File.ReadLines(inputPath).ParseInput().ToSequence().CalculatePartOne());
Console.WriteLine("Part Two: " + File.ReadLines(inputPath).ParseInput().ToSequence().CalculatePartTwo());
