using AdventOfCode.Shared;
using AdventOfCode.Shared.Enumerations;
using AdventOfCode2022.Day03;

const string inputPath = "Day03Input.txt";
Console.WriteLine("2022 - Day 3");
var input = File.ReadLines(inputPath);
Console.WriteLine("Part One: " + input.CalculatePartOne());
Console.WriteLine("Part Two: " + input.CalculatePartTwo());
