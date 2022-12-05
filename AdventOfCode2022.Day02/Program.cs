using AdventOfCode.Shared;
using AdventOfCode.Shared.Enumerations;
using AdventOfCode2022.Day02;

const string inputPath = "Day02Input.txt";
Console.WriteLine("2022 - Day 2");
var input = File.ReadLines(inputPath);
Console.WriteLine("Part One: " + input.CalculatePartOne());
Console.WriteLine("Part Two: " + input.CalculatePartTwo());
