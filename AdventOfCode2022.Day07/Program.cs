using AdventOfCode2022.Day07;

const string inputPath = "Day07Input.txt";
Console.WriteLine("2022 - Day 7");
var input = System.IO.File.ReadLines(inputPath);
Console.WriteLine("Part One: " + input.ParseInput().CalculatePartOne(100000));
Console.WriteLine("Part Two: " + input.ParseInput().CalculatePartTwo(70000000, 30000000));
