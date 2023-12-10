using AdventOfCode2023.Day04;

const string inputPath = "Day04Input.txt";
Console.WriteLine("2023 - Day 4");
var input = File.ReadLines(inputPath);
Console.WriteLine("Part One: " + input.ParseInput().CalculatePartOne());
Console.WriteLine("Part Two: " + input.ParseInput().CalculatePartTwo());
