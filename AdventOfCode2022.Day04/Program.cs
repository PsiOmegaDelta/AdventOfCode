using AdventOfCode2022.Day04;

const string inputPath = "Day04Input.txt";
Console.WriteLine("2022 - Day 4");
var input = File.ReadLines(inputPath);
Console.WriteLine("Part One: " + input.CalculatePartOne());
Console.WriteLine("Part Two: " + input.CalculatePartTwo());
