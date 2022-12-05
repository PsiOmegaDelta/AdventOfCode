using AdventOfCode.Shared;
using AdventOfCode.Shared.Enumerations;
using AdventOfCode2022.Day01;

const string inputPath = "Day01Input.txt";
Console.WriteLine("2022 - Day 1");
var input = File.ReadLines(inputPath).GroupByNewlineSeparation(int.Parse);
Console.WriteLine("Part One: " + input.CalculatePartOne());
Console.WriteLine("Part Two: " + input.CalculatePartTwo());
