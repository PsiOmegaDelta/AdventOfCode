using AdventOfCode2022.Day09;

const string inputPath = "Day09Input.txt";
Console.WriteLine("2022 - Day 9");
var input = File.ReadLines(inputPath).ParseInput();
Console.WriteLine("Part One: " + input.CalculatePartOne());
Console.WriteLine("Part Two: " + input.CalculatePartTwo(10));
