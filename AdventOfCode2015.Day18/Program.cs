using AdventOfCode2015.Day18;
using System.Collections.Immutable;

const string inputPath = "Day18Input.txt";
Console.WriteLine("2015 - Day 18");
Console.WriteLine("Part One: " + File.ReadLines(inputPath).ParseInput().CalculatePartOne(100));
Console.WriteLine("Part Two: " + File.ReadLines(inputPath).ParseInput().CalculatePartTwo(100));
