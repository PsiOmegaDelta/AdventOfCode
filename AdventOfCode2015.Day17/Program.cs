using AdventOfCode2015.Day17;
using System.Collections.Immutable;

const string inputPath = "Day17Input.txt";
Console.WriteLine("2015 - Day 17");
var input = ImmutableQueue.Create(File.ReadLines(inputPath).ParseInput().ToArray());
Console.WriteLine("Part One: " + input.CalculatePartOne(150));
Console.WriteLine("Part Two: " + input.CalculatePartTwo(150));
