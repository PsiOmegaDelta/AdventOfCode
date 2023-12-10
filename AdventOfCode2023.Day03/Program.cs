using AdventOfCode2023.Day03;

const string inputPath = "Day03Input.txt";
Console.WriteLine("2023 - Day 3");
var input = File.ReadLines(inputPath);
Console.WriteLine("Part One: " + input.ParseInput().CalculatePartOne());
Console.WriteLine("Part Two: " + input.ParseInput().CalculatePartTwo());
