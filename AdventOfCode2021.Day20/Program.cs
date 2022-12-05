using AdventOfCode2021.Day20;

const string inputPath = "Day20Input.txt";
Console.WriteLine("2021 - Day 20");
Console.WriteLine("Part One: " + File.ReadLines(inputPath).ParseInput().CalculatePartOne(2));
Console.WriteLine("Part Two: " + File.ReadLines(inputPath).ParseInput().CalculatePartTwo());
