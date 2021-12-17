using AdventOfCode.Shared.Extensions;
using AdventOfCode2015.Day16;

const string inputPath = "Day16Input.txt";
Console.WriteLine("2015 - Day 16");
Console.WriteLine("Part One: " + File.ReadLines(inputPath).ParseInput().ToSequence().CalculatePartOne(new Sue(0, 3, 7, 2, 3, 0, 0, 5, 3, 2, 1)));
Console.WriteLine("Part Two: " + File.ReadLines(inputPath).ParseInput().ToSequence().CalculatePartTwo(new Sue(0, 3, 7, 2, 3, 0, 0, 5, 3, 2, 1)));
