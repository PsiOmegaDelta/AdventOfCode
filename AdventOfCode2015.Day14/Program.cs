using AdventOfCode2015.Day14;

const string inputPath = "Day14Input.txt";
Console.WriteLine("2015 - Day 14");
Console.WriteLine("Part One: " + File.ReadLines(inputPath).ParseInput().CalculatePartOne(2503));
Console.WriteLine("Part Two: " + File.ReadLines(inputPath).ParseInput().CalculatePartTwo(2503));
