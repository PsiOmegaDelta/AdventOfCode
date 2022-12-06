using AdventOfCode2022.Day06;

const string inputPath = "Day06Input.txt";
Console.WriteLine("2022 - Day 6");
var input = File.ReadLines(inputPath);
Console.WriteLine("Part One: " + input.CalculatePartOne().Single());
Console.WriteLine("Part Two: " + input.CalculatePartTwo().Single());
