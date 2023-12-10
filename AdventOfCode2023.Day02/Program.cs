using AdventOfCode2023.Day02;

const string inputPath = "Day02Input.txt";
Console.WriteLine("2023 - Day 2");
var input = File.ReadLines(inputPath);
Console.WriteLine("Part One: " + Calculations.CalculatePartOne(12, 13, 14, input.ParseInput()));
Console.WriteLine("Part Two: " + input.ParseInput().CalculatePartTwo());
